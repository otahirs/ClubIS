using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.IdentityStore;
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
        [SwaggerResponse(StatusCodes.Status404NotFound, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News retrieved.")]
        public async Task<ActionResult<IEnumerable<PaymentListDTO>>> Get()
        {
            var payments = await _paymentFacade.GetAll();
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpGet("user")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News retrieved.")]
        public async Task<ActionResult<IEnumerable<PaymentListDTO>>> GetByUserId()
        {
            if (!User.Identity.IsAuthenticated) {
                return Unauthorized();
            }
            var userId = User.Identity.GetUserId();
            var payments = await _paymentFacade.GetAllByUserId(userId);
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpPost("transfer")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided payment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Payment added.")]
        public async Task<ActionResult> Post([FromBody] PaymentUserTransferDTO payment)
        {
            if (payment == null)
                return BadRequest();

            await _paymentFacade.Create(payment);
            return Ok();
        }
    }
}
