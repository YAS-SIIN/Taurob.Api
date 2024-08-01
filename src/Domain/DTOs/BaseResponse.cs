
using System.ComponentModel;

using Taurob.Api.Domain.DTOs.Robot;

namespace Taurob.Api.Domain.DTOs;

public class BaseResponse
{
    /// <summary>
    /// Id
    /// </summary> 
    public int Id { get; set; }

    /// <summary>
    /// Description
    /// </summary> 
    public string? Description { get; set; }

}
