
using Microsoft.EntityFrameworkCore;

using Taurob.Api.Application.UseCases.Mission.Commands;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.UnitTest.Handlers.Robot.Query;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class UpdateMissionCommand_Test
{
    private readonly UpdateMissionCommandHandler _updateMissionCommandHandler;
    private readonly UpdateMissionCommandValidator _validationRules;
    private readonly TestTools _testTools;
    public UpdateMissionCommand_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(UpdateMissionCommand_Test));
        _updateMissionCommandHandler = new UpdateMissionCommandHandler(_testTools._dbContext!);
        _validationRules = new UpdateMissionCommandValidator();

    }

    [Theory]
    [MemberData(nameof(UpdateMissionCommand_Data.SetDataFor_UpdateMission_WithEverythingIsOk), MemberType = typeof(UpdateMissionCommand_Data))] 
    public async Task UpdateMission_WhenEverythingIsOk_ShouldBeSucceeded(UpdateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseUpdateData = await _updateMissionCommandHandler.Handle(requestData, CancellationToken.None);
   
        Assert.Equal((int)EnumResponseStatus.OK, responseUpdateData.StatusCode);

        var updatedRow = await _testTools._dbContext.Missions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == responseUpdateData.Data.Id);

        Assert.NotNull(updatedRow);
        Assert.Equal(updatedRow.Name, responseUpdateData.Data.Name);
        Assert.Equal(updatedRow.RobotId, responseUpdateData.Data.RobotId);


        _testTools._dbContext.Dispose();
    }

    [Theory]
    [MemberData(nameof(UpdateMissionCommand_Data.SetDataFor_UpdateMission_WhenRobotIdIsZero_ShouldBeFailed), MemberType = typeof(UpdateMissionCommand_Data))]
    public async Task UpdateMission_WhenFirstnameIsEmpty_ShouldBeFailed(UpdateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.Equal(0, requestData.RobotId);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(UpdateMissionCommand_Data.SetDataFor_UpdateMission_WhenRobotIdNotExit_ShouldBeFailed), MemberType = typeof(UpdateMissionCommand_Data))]
    public async Task UpdateMission_WhenRobotIdNotExit_ShouldBeFailed(UpdateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.NotEqual(0, requestData.RobotId);
        Assert.True(validation.IsValid);

        await Assert.ThrowsAsync<ErrorException>(async () => await _updateMissionCommandHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();

    }

    [Theory]
    [MemberData(nameof(UpdateMissionCommand_Data.SetDataFor_UpdateMission_WhenNameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateMissionCommand_Data))]
    public async Task UpdateMission_WhenNameIsEmpty_ShouldBeFailed(UpdateMissionCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Name));
        Assert.False(validation.IsValid);
 
    }
     
    [Theory]
    [MemberData(nameof(UpdateMissionCommand_Data.SetDataFor_UpdateMission_WhenNameIsNotValid_ShouldBeFailed), MemberType = typeof(UpdateMissionCommand_Data))]
    public async Task UpdateMission_WhenNameIsNotValid_ShouldBeFailed(UpdateMissionCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Name.Length > 100);
        Assert.False(validation.IsValid); 
    }
     
}
