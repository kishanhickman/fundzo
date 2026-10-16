using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fundzo.Api.Resources;
using Fundzo.Api.Validations;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using Microsoft.Extensions.Logging;
using Fundzo.Api.Resources.Payment;
using Fundzo.Api.Validators;

namespace Fundzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        /// <summary>
        /// Private Payment service context.
        /// </summary>
        private readonly IPaymentService paymentService;

        /// <summary>
        /// Private Payment Method service context.
        /// </summary>
        private readonly IPaymentMethodService paymentMethodService;

        /// <summary>
        /// Private Payment Status service context.
        /// </summary>
        private readonly IPaymentStatusService paymentStatusService;

        /// <summary>
        /// Private mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Private logger for PaymentController.
        /// </summary>
        private readonly ILogger<PaymentController> logger;

        /// <summary>
        /// Controller constructor for dependency injection and mapping.
        /// </summary>
        /// <param name="paymentService">Injected service context.</param>
        /// <param name="paymentMethodService">Injected service context.</param>
        /// <param name="paymentStatusService">Injected service context.</param>
        /// <param name="mapper">Mapping.</param>
        /// <param name="logger">Logger.</param>
        public PaymentController(IPaymentService paymentService, IPaymentMethodService paymentMethodService, IPaymentStatusService paymentStatusService, IMapper mapper, ILogger<PaymentController> logger)
        {
            this.mapper = mapper;
            this.paymentService = paymentService;
            this.paymentMethodService = paymentMethodService;
            this.paymentStatusService = paymentStatusService;
            this.logger = logger;
        }

        /// <summary>
        /// Get all payments.
        /// </summary>
        /// <returns>200 successful operation and list of all payments.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PaymentResource>>> GetAllPayments()
        {
            try
            {
                var payments = await paymentService.GetAllPayments();
                var response = mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get payment by id.
        /// </summary>
        /// <param name="id">Id of the payment.</param>
        /// <returns>200 successful operation and the payment or 404 payment not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResource>> GetPaymentById(int id)
        {
            try
            {
                var payment = await paymentService.GetPaymentById(id);
                var response = mapper.Map<Payment, PaymentResource>(payment);

                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new payment and adds it to the system.
        /// </summary>
        /// <param name="savePaymentResource">Body of the payment.</param>
        /// <returns>200 successful operation and new payment was created or 400 bad request.</returns>
        [HttpPost("")]
        public async Task<ActionResult<PaymentResource>> CreatePayment([FromBody] SavePaymentResource savePaymentResource)
        {
            try
            {
                var validator = new SavePaymentResourceValidator();
                var validationResult = await validator.ValidateAsync(savePaymentResource);

                if (!validationResult.IsValid)
                {
                    // This needs refining, but for demo it is ok.
                    return BadRequest(validationResult.Errors);
                }

                // Map Resource to Domain: Create new payment.
                var newPayment = await paymentService.CreatePayment(mapper.Map<SavePaymentResource, Payment>(savePaymentResource));

                // Map Domain to Resource: Return to API friendly response.
                var paymentResource = mapper.Map<Payment, PaymentResource>(await paymentService.GetPaymentById(newPayment.Id));

                return Ok(paymentResource);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit payment information.
        /// </summary>
        /// <param name="id">Id of the payment.</param>
        /// <param name="savePaymentResource">Body of the payment.</param>
        /// <returns>200 successful operation and the payment was edited or 400/404 error.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentResource>> UpdatePayment(int id, [FromBody] SavePaymentResource savePaymentResource)
        {
            try
            {
                var validator = new SavePaymentResourceValidator();
                var validationResult = await validator.ValidateAsync(savePaymentResource);

                if (!validationResult.IsValid)
                {
                    // This needs refining, but for demo it is ok.
                    return BadRequest(validationResult.Errors);
                }

                // Find existing payment.
                var payment = await paymentService.GetPaymentById(id);

                if (payment == null)
                {
                    return NotFound();
                }

                // Map Resource to Domain: Update payment.
                var updatedPayment = await paymentService.UpdatePayment(mapper.Map<SavePaymentResource, Payment>(savePaymentResource));

                // Map Domain to Resource: Return to API friendly response.
                var paymentResource = mapper.Map<Payment, PaymentResource>(await paymentService.GetPaymentById(updatedPayment.Id));

                return Ok(paymentResource);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete payment.
        /// </summary>
        /// <param name="id">Id of the payment.</param>
        /// <returns>200 successful operation and the payment was deleted or 404 payment was not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                // Find existing payment.
                var payment = await paymentService.GetPaymentById(id);

                if (payment == null)
                {
                    return NotFound();
                }

                await paymentService.DeletePayment(payment);

                return Ok("Record deleted sucessfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all payment methods.
        /// </summary>
        /// <returns>200 successful operation and list of all payment methods.</returns>
        [HttpGet("PaymentMethod")]
        public async Task<ActionResult<IEnumerable<PaymentMethodResource>>> GetAllPaymentMethods()
        {
            try
            {
                var paymentMethods = await paymentMethodService.GetAllPaymentMethods();
                var response = mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(paymentMethods);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get payment method by id.
        /// </summary>
        /// <param name="id">Id of the payment method.</param>
        /// <returns>200 successful operation and the payment method or 404 payment method not found.</returns>
        [HttpGet("PaymentMethod/{id}")]
        public async Task<ActionResult<PaymentMethodResource>> GetPaymentMethodById(int id)
        {
            try
            {
                var paymentMethod = await paymentMethodService.GetPaymentMethodById(id);
                var response = mapper.Map<PaymentMethod, PaymentMethodResource>(paymentMethod);

                if (paymentMethod == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all payment statuses.
        /// </summary>
        /// <returns>200 successful operation and list of all payment statuses.</returns>
        [HttpGet("PaymentStatus")]
        public async Task<ActionResult<IEnumerable<PaymentStatusResource>>> GetAllPaymentStatuses()
        {
            try
            {
                var paymentStatuses = await paymentStatusService.GetAllPaymentStatuses();
                var response = mapper.Map<IEnumerable<PaymentStatus>, IEnumerable<PaymentStatusResource>>(paymentStatuses);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get payment status by id.
        /// </summary>
        /// <param name="id">Id of the payment status.</param>
        /// <returns>200 successful operation and the payment status or 404 payment status not found.</returns>
        [HttpGet("PaymentStatus/{id}")]
        public async Task<ActionResult<PaymentStatusResource>> GetPaymentStatusById(int id)
        {
            try
            {
                var paymentStatus = await paymentStatusService.GetPaymentStatusById(id);
                var response = mapper.Map<PaymentStatus, PaymentStatusResource>(paymentStatus);

                if (paymentStatus == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
