
using System.ComponentModel;

namespace Taurob.Api.Domain.DTOs.Robot;

public class RobotResponse : BaseResponse
{
    /// <summary>
    /// Name of robot
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Model name of robot
    /// </summary>
    public string Modelname { get; set; }
}
