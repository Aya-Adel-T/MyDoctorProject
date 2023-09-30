using Microsoft.AspNetCore.Mvc;
using PaypalCheckoutExample.Clients;

namespace PaypalCheckoutExample.Controllers
{
    public class PaypalController : Controller
    {
        private readonly PaypalClient _paypalClient;

        public PaypalController(PaypalClient paypalClient)
        {
            this._paypalClient = paypalClient;
        }

        public IActionResult Index()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _paypalClient.ClientId;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "25.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order1(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "15.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order2(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "12.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order3(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "6.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order4(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "45.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order5(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "9.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Order6(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "10.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Orderconsultant(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "1.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderId);

                var reference = "INV001";

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult SuccessAll()
        {
            return View();
        }

        public IActionResult Index1()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _paypalClient.ClientId;

            return View();
        }
        public IActionResult Payment10()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _paypalClient.ClientId;

            return View();
        }
    }
}