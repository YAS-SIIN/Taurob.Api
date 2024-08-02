
using Taurob.Api.Application.Application.UseCases.Missions.Queries;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.UnitTest;

namespace Mc2.CrudTest.UnitTest.Handlers.Mission.Query;

public class GetMissionQuery_Test
{
    private readonly GetMissionQueryHandler _getMissionQueryHandler;
    public GetMissionQuery_Test()
    {

        TestTools.Initialize();
        _getMissionQueryHandler = new GetMissionQueryHandler(TestTools._dbContext!);

    }

    [Theory]
    [InlineData(1)]
    public async Task GetMission_ShouldBeSucceeded(int id)
    { 
        var requestData = new GetMissionQuery { Id = id };
        var responseData = await _getMissionQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        TestTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task GetMission_ShouldBeFailed(int id)
    {

        var requestData = new GetMissionQuery { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _getMissionQueryHandler.Handle(requestData, CancellationToken.None));
        TestTools._dbContext?.Dispose();
    }

}
