using Asp.Versioning;
using CleanArc.Infrastructure.Identity.Identity.PermissionManager;
using CleanArc.WebFramework.BaseController;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CleanArc.Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/CardManagement")]
    [Display(Description = "Managing Users related Cards")]
    [Authorize(ConstantPolicies.DynamicPermission)]
    public class CardManagementController : BaseController
    {
        private readonly ISender _sender;

        public CardManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("CardList")]
        public async Task<IActionResult> GetCards()
        {
            var queryResult = await _sender.Send(new Application.Features.Card.Queries.GetAllCards.GetAllCardsQuery());

            return base.OperationResult(queryResult);
        }
    }
}
