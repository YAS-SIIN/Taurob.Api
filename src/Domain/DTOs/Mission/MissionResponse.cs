
using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Domain.DTOs.Mission;

public class MissionResponse : BaseResponse
{
    /// <summary>
    /// Name of mission
    /// </summary>
    [DisplayName("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Robot foreign key
    /// </summary>
    [DisplayName("Robot")]
    public int RobotId { get; set; }
     
    public  RobotResponse? RobotResponse { get; set; }

}
