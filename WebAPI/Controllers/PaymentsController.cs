using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using ClubIS.IdentityStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private IPaymentFacade _paymentFacade;

        public PaymentsController(IPaymentFacade paymentFacade)
        {
            _paymentFacade = paymentFacade;
        }

        [HttpGet]
        [Authorize(Policy = Policy.Finance)]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No payments found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Payments retrieved.")]
        public async Task<ActionResult<IEnumerable<PaymentListDTO>>> Get()
        {
            var payments = await _paymentFacade.GetAll();
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpGet("statements")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Statements not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Statements retrieved.")]
        public async Task<ActionResult<IEnumerable<FinanceStatementDTO>>> GetByUserId()
        {
            var userId = User.Identity.GetUserId();
            var financeStatements = await _paymentFacade.GetAllFinanceStatement(userId);
            if (financeStatements == null)
            {
                return NotFound();
            }
            return Ok(financeStatements);
        }

        [HttpPost("transfer")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided payment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Payment added.")]
        public async Task<ActionResult> Post([FromBody] PaymentUserTransferDTO payment)
        {
            if (User.Identity.GetUserId() != payment.SourceUserId && //TODO allow transfers from supervised accounts
               !User.IsInRole(Role.Finance) &&
               !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }

            if (payment == null)
                return BadRequest();

            await _paymentFacade.Create(payment);
            return Ok();
        }

        [HttpGet("member-fee-types")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Member fee types not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Member fee types retrieved.")]
        public async Task<ActionResult<IEnumerable<MemberFeeDTO>>> GetAllMemberFeeTypes()
        {
            var memberFeeTypes = await _paymentFacade.GetAllMemberFeeTypes();
            if (memberFeeTypes == null)
            {
                return NotFound();
            }
            return Ok(memberFeeTypes);
        }
    }
}
