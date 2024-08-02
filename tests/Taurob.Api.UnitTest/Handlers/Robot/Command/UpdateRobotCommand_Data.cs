using Taurob.Api.Core.Commands.Robot;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class UpdateRobotCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_UpdateRobot_WithEverythingIsOk()
    {
        yield return new object[] { new UpdateRobotCommand() {
            Id = 2,
            Name = "Yasin2",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }
     
    public static IEnumerable<object[]> SetDataFor_UpdateRobot_WhenNameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateRobotCommand() {
            Id = 2,
            Name = "",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }
          
    public static IEnumerable<object[]> SetDataFor_UpdateRobot_WhenNameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new UpdateRobotCommand() {
            Id = 2,
            Name = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbddddddddddddddd",
            Modelname = "YasinModel",
            Description = "Asadnezhad",
            }
        };
    }       
    
    public static IEnumerable<object[]> SetDataFor_UpdateRobot_WhenModelnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateRobotCommand() {
            Id = 2,
            Name = "Yasin2",
            Modelname = "",
            Description = "Asadnezhad",
            }
        };
    }
          
    public static IEnumerable<object[]> SetDataFor_UpdateRobot_WhenModelnameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new UpdateRobotCommand() {
            Id = 2,
            Name = "Yasin2",
            Modelname = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbddddddddddddddd",
            Description = "Asadnezhad",
            }
        };
    }       

}
