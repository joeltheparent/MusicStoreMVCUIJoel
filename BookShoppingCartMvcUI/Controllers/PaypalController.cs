using Microsoft.AspNetCore.Mvc;
using BookShoppingCartMvcUI.Client;
using BookShoppingCartMvcUI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BookShoppingCartMvcUI.Controllers
{
    public class PaypalController : Controller
    {
        private readonly PaypalClient _paypalClient;
        private readonly ICartRepository _cartRepo;
        private readonly ShoppingCart _shoppingcart;

        public PaypalController(PaypalClient paypalClient, CartDetail cartDetail, ICartRepository cartRepo, ShoppingCart shoppingcart)
        {
            this._paypalClient = paypalClient;
            this._cartRepo = cartRepo;
            this._shoppingcart = shoppingcart;
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
            {// Get the total amount of the cart
                var totalAmount = _cartRepo.GetTotalAmount();
                var price = totalAmount.ToString("F2"); // Format the price
                //var price = "100.00";
                var currency = "USD";
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);


                // set the transaction price and currency
                //this is where you need to change and pass the total amount of the cart
                //var price = "100.00";
                //var currency = "USD";

                //// "reference" is the transaction key
                //var reference = "INV001";

                //var response = await _paypalClient.CreateOrder(price, currency, reference);

                //return Ok(response);
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

                //var reference = response.purchase_units[0].reference_id;




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
    }
}
