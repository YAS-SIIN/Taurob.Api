
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.ComponentModel.DataAnnotations;

using Taurob.Api.Domain.Common;

namespace Taurob.Api.Domain.Entities;

/// <summary>
/// Mission Entity
/// </summary>
public class Mission : BaseEntity<int>
{
    public Mission() { }
    /// <summary>
    /// Name of mission
    /// </summary>
    public string Name { get; set; }
    public Robot Robot { get; set; }

}

/// <summary>
/// Configuration of mission entity
/// </summary>
public class MissionEntityTypeConfiguration : IEntityTypeConfiguration<Mission>
{
    public void Configure(EntityTypeBuilder<Mission> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);  
    }
}