
using Taurob.Api.Application.UseCases.Mission.Commands;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class CreateMissionCommand_Test
{
    private readonly CreateMissionCommandHandler _createMissionCommandHandler;
    private readonly CreateMissionCommandValidator _validationRules;
    private readonly TestTools _testTools;
    public CreateMissionCommand_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(CreateMissionCommand_Test));
        _createMissionCommandHandler = new CreateMissionCommandHandler(_testTools._dbContext!);
        _validationRules = new CreateMissionCommandValidator();
    }

    [Theory]
    [MemberData(nameof(CreateMissionCommand_Data.SetDataFor_CreateMission_WithEverythingIsOk), MemberType = typeof(CreateMissionCommand_Data))]
    public async Task CreateMission_WhenEverythingIsOk_ShouldBeSucceeded(CreateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseData = await _createMissionCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);

        var insertedRow = await _testTools._dbContext.Missions.FindAsync(responseData.Data.Id);

        Assert.NotNull(insertedRow);
        Assert.Equal(insertedRow.Name, responseData.Data.Name);
        Assert.Equal(insertedRow.RobotId, responseData.Data.RobotId);

        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [MemberData(nameof(CreateMissionCommand_Data.SetDataFor_CreateMission_WhenRobotIdIsZero_ShouldBeFailed), MemberType = typeof(CreateMissionCommand_Data))]
    public async Task CreateMission_WhenRobotIdIsZero_ShouldBeFailed(CreateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.Equal(0, requestData.RobotId);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateMissionCommand_Data.SetDataFor_CreateMission_WhenRobotIdNotExit_ShouldBeFailed), MemberType = typeof(CreateMissionCommand_Data))]
    public async Task CreateMission_WhenRobotIdNotExit_ShouldBeFailed(CreateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);
        Assert.NotEqual(0, requestData.RobotId);

        await Assert.ThrowsAsync<ErrorException>(async () => await _createMissionCommandHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();

    }

    [Theory]
    [MemberData(nameof(CreateMissionCommand_Data.SetDataFor_CreateMission_WhenNameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateMissionCommand_Data))]
    public async Task CreateMission_WhenNameIsEmpty_ShouldBeFailed(CreateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Name));
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateMissionCommand_Data.SetDataFor_CreateMission_WhenNameIsNotValid_ShouldBeFailed), MemberType = typeof(CreateMissionCommand_Data))]
    public async Task CreateMission_WhenNameIsNotValid_ShouldBeFailed(CreateMissionCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Name.Length > 100);
        Assert.False(validation.IsValid);
    }

}
