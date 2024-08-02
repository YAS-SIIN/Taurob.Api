

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
              new Robot { Name = "Yasin", Modelname = "Asadnezhad" },
              new Robot { Name = "Test1", Modelname = "Test1" },
              new Robot { Name = "Test2", Modelname = "Test2" },
              new Robot { Name = "Test3", Modelname = "Test3" },
        };
            _dbContext.Robots.AddRange(robot);
            _dbContext.SaveChanges();
        }
        // Add new mission
        if (!_dbContext.Missions.Any())
        {
            List<Mission> mission = new() {
              new Mission { Name = "Yasin", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
              new Mission { Name = "Test1", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
              new Mission { Name = "Test2", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
              new Mission { Name = "Test3", RobotId = _dbContext.Robots.FirstOrDefault()?.Id ?? 0 },
        };
            _dbContext.Missions.AddRange(mission);
            _dbContext.SaveChanges();
        }

        //dbContext?.Dispose();
    }
}
