

using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Taurob.Api.Domain.Entities;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.UnitTest;

public class TestTools
{ 
    public TaurobDBContext? _dbContext; 

    public void Initialize(string testClassName)
    {
        InitializeDBContext(testClassName);
        SeedData();
    }

    /// <summary>
    /// Inject DbContext
    /// </summary>
    public void InitializeDBContext(string testClassName)
    {
        DbContextOptionsBuilder<TaurobDBContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<TaurobDBContext>();
        dbContextOptionsBuilder.UseInMemoryDatabase($"AppDbContext_{testClassName}");
        DbContextOptions<TaurobDBContext>? contextOptions = dbContextOptionsBuilder.Options;
        _dbContext = new TaurobDBContext(contextOptions);
    }
    /// <summary>
    /// Initializing new data
    /// </summary>
    public void SeedData()
    {
        // Add new robots
        if (!_dbContext.Robots.Any())
        {
            List<Robot> robot = new() {
           new Robot { Name = "Robot1", Modelname = "Robot Model 1", Description = "Test Robot 1" },
              new Robot { Name = "Robot2", Modelname = "Robot Model 2", Description = "Test Robot 2" },
              new Robot { Name = "Robot3", Modelname = "Robot Model 3", Description = "Test Robot 3" },
              new Robot { Name = "Robot4", Modelname = "Robot Model 4", Description = "Test Robot 4" },
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
              new Mission { Name = "Mission4", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0, Description = "Test Mission 4" },
        };
            _dbContext.Missions.AddRange(mission);
            _dbContext.SaveChanges();
        }

        //dbContext?.Dispose();
    }
}
