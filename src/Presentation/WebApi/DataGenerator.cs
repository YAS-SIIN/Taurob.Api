
using System.Reflection;

using Taurob.Api.Domain.Entities;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Presentation.WebApi;

public class DataGenerator
{
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void SeedData(IServiceProvider serviceProvider)
    {
        var _dbContext = serviceProvider.GetRequiredService<TaurobDBContext>();
        // Add new robots
        if (!_dbContext.Robots.Any())
        {
            List<Robot> robot = new() {
              new Robot { Name = "Robot1", Modelname = "Robot Model 1", Description = "Test Robot 1" },
              new Robot { Name = "Robot2", Modelname = "Robot Model 2", Description = "Test Robot 2" },
              new Robot { Name = "Robot3", Modelname = "Robot Model 3", Description = "Test Robot 3" },
        };
            _dbContext.Robots.AddRange(robot);
            _dbContext.SaveChanges();
        }
        // Add new mission
        if (!_dbContext.Missions.Any())
        {
            List<Mission> mission = new() {
              new Mission { Name = "Mission1", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0, Description = "Test Mission 1" },
              new Mission { Name = "Mission2", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0, Description = "Test Mission 2" },
              new Mission { Name = "Mission3", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0, Description = "Test Mission 3" },
        };
            _dbContext.Missions.AddRange(mission);
            _dbContext.SaveChanges();
        }

    }
}
