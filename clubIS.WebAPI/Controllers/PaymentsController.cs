using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Facades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace clubIS.WebAPI.Controllers
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

        [HttpGet("{userId}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News retrieved.")]
        public async Task<ActionResult<IEnumerable<PaymentListDTO>>> Get([Range(1, int.MaxValue)] int userId)
        {
            var payments = await _paymentFacade.GetAllByUserId(userId);
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided payment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Payment added.")]
        public async Task<ActionResult> Post([FromBody] PaymentSendDTO payment)
        {
            if (payment == null)
                return BadRequest();

            await _paymentFacade.Create(payment);
            return Ok();
        }
    }
}
