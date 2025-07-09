using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RoutingSlipLostVariable.StateMachines.Contracts;

namespace RoutingSlipLostVariable.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimRewardController(
        IPublishEndpoint _publishEndpoint
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            Guid submissionId = NewId.NextGuid();

            await _publishEndpoint.Publish(new ClaimRewardRequested
            {
                SubmissionId = submissionId,
                CustomerGuid = "CustomerGuid",
                RewardId = "RewardId"
            },
            cancellationToken);

            return Ok();
        }
    }
}
