using Taurob.Api.Core.Commands.Mission;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class UpdateMissionCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_UpdateMission_WithEverythingIsOk()
    {
        yield return new object[] { new UpdateMissionCommand() {
            Id = 2,
            Name = "Yasin2",
            Description = "Asadnezhad",
            RobotId = 1,
            }
        };
    }

    public static IEnumerable<object[]> SetDataFor_UpdateMission_WhenRobotIdIsZero_ShouldBeFailed()
    {
        yield return new object[] { new UpdateMissionCommand() {
            Id = 1,
            Name = "Yasin",
            Description = "Asadnezhad",
            RobotId = 0,
            }
        };
    }

    public static IEnumerable<object[]> SetDataFor_UpdateMission_WhenRobotIdNotExit_ShouldBeFailed()
    {
        yield return new object[] { new UpdateMissionCommand() {
            Id = 1,
            Name = "Yasin",
            Description = "Asadnezhad",
            RobotId = 1000,
            }
        };
    }

    public static IEnumerable<object[]> SetDataFor_UpdateMission_WhenNameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateMissionCommand() {
            Id = 2,
            Name = "",
            Description = "Asadnezhad",
            RobotId = 1,
            }
        };
    }
          
    public static IEnumerable<object[]> SetDataFor_UpdateMission_WhenNameIsNotValid_ShouldBeFailed()
    {
        yield return new object[] { new UpdateMissionCommand() {
            Id = 2,
            Name = "aasssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbddddddddddddddd",
            Description = "Asadnezhad",
            RobotId = 1,
            }
        };
    }       

}
