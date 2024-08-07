using Asp.Versioning;
using CleanArc.Application.Features.Card.Commands;
using CleanArc.Application.Features.Card.Queries.GetUserCards;
using CleanArc.WebFramework.BaseController;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArc.Web.Api.Controllers.V1.Card
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/User")]
    [Authorize]
    public class CardController(ISender sender) : BaseController
    {
        [HttpPost("CreateNewCard")]
        public async Task<IActionResult> CreateNewCard(AddCardCommand model)
        {
            var command = await sender.Send(model);

            return base.OperationResult(command);
        }

        [HttpGet("GetUserCards")]
        public async Task<IActionResult> GetUserCards()
        {
            var query = await sender.Send(new GetUserCardsQueryModel(UserId));

            return base.OperationResult(query);
        }

        [HttpPut("UpdateCard")]
        public async Task<IActionResult> UpdateCard(Application.Features.Card.Commands.UpdateUserCardCommand model)
        {
            model.UserId = base.UserId;

            var command = await sender.Send(model);

            return base.OperationResult(command);
        }

        [HttpDelete("DeleteAllUserCards")]
        public async Task<IActionResult> DeleteAllUserCards()
            => base.OperationResult(await sender.Send(new DeleteUserCardsCommand(base.UserId)));
    }
}
