
using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Domain.DTOs.Mission;

public class MissionResponse : BaseResponse
{ 
    /// <summary>
    /// Name of mission
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Robot of mission
    /// </summary>
    public RobotResponse RobotData { get; set; }

}
