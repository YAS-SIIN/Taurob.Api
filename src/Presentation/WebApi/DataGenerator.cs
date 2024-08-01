
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
              new Robot { Name = "Yasin", Modelname = "Asadnezhad" },
              new Robot { Name = "Test", Modelname = "Test1" },
        };
            _dbContext.Robots.AddRange(robot);
            _dbContext.SaveChanges();
        }
        // Add new mission
        if (!_dbContext.Missions.Any())
        {
            List<Mission> mission = new() {
              new Mission { Name = "Yasin", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
              new Mission { Name = "Test", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
        };
            _dbContext.Missions.AddRange(mission);
            _dbContext.SaveChanges();
        }

    }
}
