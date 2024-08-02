
using Taurob.Api.Application.Application.UseCases.Missions.Queries;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.UnitTest;
using Taurob.Api.UnitTest.Handlers.Robot.Query;

namespace Taurob.Api.UnitTest.Handlers.Mission.Query;

public class GetMissionQuery_Test
{
    private readonly GetMissionQueryHandler _getMissionQueryHandler;
    private readonly TestTools _testTools;
    public GetMissionQuery_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(GetMissionQuery_Test));
        _getMissionQueryHandler = new GetMissionQueryHandler(_testTools._dbContext!);

    }

    [Theory]
    [InlineData(4)]
    public async Task GetMission_ShouldBeSucceeded(int id)
    { 
        var requestData = new GetMissionQuery { Id = id };
        var responseData = await _getMissionQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task GetMission_ShouldBeFailed(int id)
    {

        var requestData = new GetMissionQuery { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _getMissionQueryHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();
    }

}
