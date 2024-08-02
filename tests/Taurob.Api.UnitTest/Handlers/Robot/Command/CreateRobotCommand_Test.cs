
using Taurob.Api.Application.UseCases.Robot.Commands;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class CreateRobotCommand_Test
{
    private readonly CreateRobotCommandHandler _createRobotCommandHandler;
    private readonly CreateRobotCommandValidator _validationRules;
    public CreateRobotCommand_Test()
    {
        TestTools.Initialize();
        _createRobotCommandHandler = new CreateRobotCommandHandler(TestTools._dbContext!);
        _validationRules = new CreateRobotCommandValidator();
    }

    [Theory]
    [MemberData(nameof(CreateRobotCommand_Data.SetDataFor_CreateRobot_WithEverythingIsOk), MemberType = typeof(CreateRobotCommand_Data))]
    public async Task CreateRobot_WhenEverythingIsOk_ShouldBeSucceeded(CreateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseData = await _createRobotCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);

        var insertedRow = await TestTools._dbContext.Robots.FindAsync(responseData.Data.Id);

        Assert.NotNull(insertedRow);
        Assert.Equal(insertedRow.Name, responseData.Data.Name);
        Assert.Equal(insertedRow.Modelname, responseData.Data.Modelname);

        TestTools._dbContext?.Dispose();
    }

    [Theory]
    [MemberData(nameof(CreateRobotCommand_Data.SetDataFor_CreateRobot_WhenNameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateRobotCommand_Data))]
    public async Task CreateRobot_WhenNameIsEmpty_ShouldBeFailed(CreateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Name));
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateRobotCommand_Data.SetDataFor_CreateRobot_WhenNameIsNotValid_ShouldBeFailed), MemberType = typeof(CreateRobotCommand_Data))]
    public async Task CreateRobot_WhenNameIsNotValid_ShouldBeFailed(CreateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Name.Length > 100);
        Assert.False(validation.IsValid);
    }
    
    [Theory]
    [MemberData(nameof(CreateRobotCommand_Data.SetDataFor_CreateRobot_WhenModelnameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateRobotCommand_Data))]
    public async Task CreateRobot_WhenModelnameIsEmpty_ShouldBeFailed(CreateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(string.IsNullOrWhiteSpace(requestData.Modelname));
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateRobotCommand_Data.SetDataFor_CreateRobot_WhenModelnameIsNotValid_ShouldBeFailed), MemberType = typeof(CreateRobotCommand_Data))]
    public async Task CreateRobot_WhenModelnameIsNotValid_ShouldBeFailed(CreateRobotCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(requestData.Modelname.Length > 100);
        Assert.False(validation.IsValid);
    }

}
