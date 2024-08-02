
using FluentValidation;

using Taurob.Api.Application.Application.UseCases.Missions.Queries;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.UnitTest;
namespace Mc2.CrudTest.UnitTest.Handlers.Mission.Query;

public class GetAllMissionQuery_Test
{
    private readonly GetAllMissionQueryHandler _getAllMissionQueryHandler;
    public GetAllMissionQuery_Test()
    {

        TestTools.Initialize();
        _getAllMissionQueryHandler = new GetAllMissionQueryHandler(TestTools._dbContext!);

    }

    [Fact]
    public async Task GetAllMission_ShouldBeSucceeded()
    { 
        var requestData = new GetAllMissionQuery();
        var responseData = await _getAllMissionQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        Assert.NotEqual(0, responseData.Data.Count);
    }
     
}
