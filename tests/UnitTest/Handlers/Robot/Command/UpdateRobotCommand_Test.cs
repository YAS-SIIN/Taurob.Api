
using Microsoft.EntityFrameworkCore;

using Taurob.Api.Application.UseCases.Robot.Commands;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class UpdateRobotCommand_Test
{
    private readonly UpdateRobotCommandHandler _updateRobotCommandHandler;
    private readonly UpdateRobotCommandValidator _validationRules;
    private readonly TestTools _testTools;
    public UpdateRobotCommand_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(UpdateRobotCommand_Test));
        _updateRobotCommandHandler = new UpdateRobotCommandHandler(_testTools._dbContext!);
        _validationRules = new UpdateRobotCommandValidator();

    }

    [Theory]
    [MemberData(nameof(UpdateRobotCommand_Data.SetDataFor_UpdateRobot_WithEverythingIsOk), MemberType = typeof(UpdateRobotCommand_Data))] 
    public async Task UpdateRobot_WhenEverythingIsOk_ShouldBeSucceeded(UpdateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseUpdateData = await _updateRobotCommandHandler.Handle(requestData, CancellationToken.None);
   
        Assert.Equal((int)EnumResponseStatus.OK, responseUpdateData.StatusCode);

        var updatedRow = await _testTools._dbContext.Robots.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == responseUpdateData.Data.Id);

        Assert.NotNull(updatedRow);
        Assert.Equal(updatedRow.Name, responseUpdateData.Data.Name); 


        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [MemberData(nameof(UpdateRobotCommand_Data.SetDataFor_UpdateRobot_WhenNameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateRobotCommand_Data))]
    public async Task UpdateRobot_WhenNameIsEmpty_ShouldBeFailed(UpdateRobotCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Name));
        Assert.False(validation.IsValid);
 
    }
     
    [Theory]
    [MemberData(nameof(UpdateRobotCommand_Data.SetDataFor_UpdateRobot_WhenNameIsNotValid_ShouldBeFailed), MemberType = typeof(UpdateRobotCommand_Data))]
    public async Task UpdateRobot_WhenNameIsNotValid_ShouldBeFailed(UpdateRobotCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Name.Length > 100);
        Assert.False(validation.IsValid); 
    }
     
    [Theory]
    [MemberData(nameof(UpdateRobotCommand_Data.SetDataFor_UpdateRobot_WhenModelnameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateRobotCommand_Data))]
    public async Task UpdateRobot_WhenModelnameIsEmpty_ShouldBeFailed(UpdateRobotCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Modelname));
        Assert.False(validation.IsValid);
 
    }
     
    [Theory]
    [MemberData(nameof(UpdateRobotCommand_Data.SetDataFor_UpdateRobot_WhenModelnameIsNotValid_ShouldBeFailed), MemberType = typeof(UpdateRobotCommand_Data))]
    public async Task UpdateRobot_WhenModelnameIsNotValid_ShouldBeFailed(UpdateRobotCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Modelname.Length > 100);
        Assert.False(validation.IsValid); 
    }
     
}
