

using Taurob.Api.Core.Commands.Robot;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class CreateRobotCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_CreateRobot_WithEverythingIsOk()
    {
        yield return new object[] { new CreateRobotCommand() {
            Name = "Yasin",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }

    public static IEnumerable<object[]> SetDataFor_CreateRobot_WhenNameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new CreateRobotCommand() {
            Name = "",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateRobot_WhenNameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new CreateRobotCommand() {
            Name = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbdddddddddddddddddddd",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateRobot_WhenModelnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new CreateRobotCommand() {
            Name = "Yasin",
            Modelname = "",
            Description = "Asadnezhad",
            }
        };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateRobot_WhenModelnameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new CreateRobotCommand() {
            Name = "Yasin",
            Modelname = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbdddddddddddddddddddd",
            Description = "Asadnezhad",
            }
        };
    }

}
