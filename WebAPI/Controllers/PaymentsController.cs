using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
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
        private readonly IPaymentFacade _paymentFacade;

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
                return NotFound();
            return Ok(payments);
        }

        [HttpGet("statements/{userId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Statements not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Statements retrieved.")]
        public async Task<ActionResult<IEnumerable<FinanceStatementDTO>>> GetByUserId(int userId)
        {
            if (User.Identity.GetUserId() != userId && !User.IsInRole(Role.Finance) && !User.IsInRole(Role.Admin))
                return Unauthorized();
            var financeStatements = await _paymentFacade.GetAllFinanceStatement(userId);
            if (financeStatements == null)
                return NotFound();
            return Ok(financeStatements);
        }

        [HttpPost("transfer")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided payment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Payment added.")]
        public async Task<ActionResult> Post([FromBody] PaymentUserTransferDTO payment)
        {
            if (User.Identity.GetUserId() != payment.SourceUserId && //TODO allow transfers from supervised accounts
                !User.IsInRole(Role.Finance) && !User.IsInRole(Role.Admin))
                return Unauthorized();

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
                return NotFound();
            return Ok(memberFeeTypes);
        }

        [HttpPut("member-fee-types")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult> EditMemberFeeType([FromBody] MemberFeeDTO feeType)
        {
            if (feeType == null)
                return BadRequest();

            await _paymentFacade.UpdateMemberFee(feeType);
            return Ok();
        }

        [HttpPost("member-fee-types")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult> CreateMemberFeeTypes([FromBody] MemberFeeDTO feeType)
        {
            if (feeType == null)
                return BadRequest();

            await _paymentFacade.CreateMemberFee(feeType);
            return Ok();
        }

        [HttpGet("users")]
        [Authorize(Policy = Policy.Finance)]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Users not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved.")]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> GetUsers()
        {
            var users = await _paymentFacade.GetAllUserCreditList();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpPost("give-credit")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult> GiveCredit([FromBody] PaymentGiveCreditDTO payment)
        {
            if (payment == null)
                return BadRequest();

            await _paymentFacade.Create(payment, User.Identity.GetUserId());
            return Ok();
        }

        [HttpPost("take-credit")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult> TakeCredit([FromBody] PaymentTakeCreditDTO payment)
        {
            if (payment == null)
                return BadRequest();

            await _paymentFacade.Create(payment, User.Identity.GetUserId());
            return Ok();
        }


        [HttpGet("events/{eventId}")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult<IEnumerable<PaymentEntryListDTO>>> GetPaymentEntryList(int eventId)
        {
            var eventPayments = await _paymentFacade.GetPaymentEntryListByEventId(eventId);
            if (eventPayments == null)
                return NotFound();
            return Ok(eventPayments);
        }

        [HttpPost("events/{eventId}")]
        [Authorize(Policy = Policy.Finance)]
        public async Task<ActionResult> UpdatePaymentEntryList([FromBody] IEnumerable<PaymentEntryListDTO> payments)
        {
            if (payments == null)
                return BadRequest();

            await _paymentFacade.UpdatePaymentEntryList(payments, User.Identity.GetUserId());
            return Ok();
        }
    }
}