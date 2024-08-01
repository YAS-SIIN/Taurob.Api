
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.ComponentModel.DataAnnotations;

using Taurob.Api.Domain.Common;

namespace Taurob.Api.Domain.Entities;

/// <summary>
/// Robot entity
/// </summary>
public class Robot : BaseEntity<int>
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


/// <summary>
/// Configuration of robot entity
/// </summary>
public class RobotEntityTypeConfiguration : IEntityTypeConfiguration<Robot>
{
    public void Configure(EntityTypeBuilder<Robot> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Modelname).IsRequired().HasMaxLength(100); 
    }
}