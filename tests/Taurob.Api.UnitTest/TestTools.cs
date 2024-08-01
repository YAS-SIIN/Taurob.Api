

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

public static class TestTools
{ 
    public static TaurobDBContext? _dbContext; 

    public static void Initialize()
    {
        InitializeDBContext();
        SeedData();
    }

    /// <summary>
    /// Inject DbContext
    /// </summary>
    public static void InitializeDBContext()
    {
        DbContextOptionsBuilder<TaurobDBContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<TaurobDBContext>(); 
        dbContextOptionsBuilder.UseInMemoryDatabase("Mc2CrudTestDbContext");
        DbContextOptions<TaurobDBContext>? contextOptions = dbContextOptionsBuilder.Options;
        _dbContext = new TaurobDBContext(contextOptions); 
    }
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void SeedData()
    {
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
