

using Taurob.Api.Core.Commands.Mission;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class CreateMissionCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_CreateMission_WithEverythingIsOk()
    {
        yield return new object[] { new CreateMissionCommand() {
            Name = "Yasin",
            Description = "Asadnezhad",
            RobotId = 1,
            }
        };
    }

    public static IEnumerable<object[]> SetDataFor_CreateMission_WhenRobotIdIsZero_ShouldBeFailed()
    {
        yield return new object[] { new CreateMissionCommand() {
            Name = "Yasin",
            Description = "Asadnezhad",
            RobotId = 0,
            }
        };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateMission_WhenRobotIdNotExit_ShouldBeFailed()
    {
        yield return new object[] { new CreateMissionCommand() {
            Name = "Yasin",
            Description = "Asadnezhad",
            RobotId = 1000,
            }
        };
    }


    public static IEnumerable<object[]> SetDataFor_CreateMission_WhenNameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new CreateMissionCommand() {
            Name = "",
            Description = "Asadnezhad",
            RobotId = 1000,
            }
        };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateMission_WhenNameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new CreateMissionCommand() {
            Name = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbdddddddddddddddddddd",
            Description = "Asadnezhad",
            RobotId = 1000,
            }
        };
    }

}
