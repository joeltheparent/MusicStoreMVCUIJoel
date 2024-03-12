using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Stripe.Checkout;

//namespace BookShoppingCartMvcUI.Controllers
//{
//    [Authorize]
//    public class CheckoutController : Controller
//    {
//        private readonly ICartRepository _cartRepository;
//        private readonly ShoppingCart _shoppingCart;

//        public CheckoutController(ICartRepository cartRepository, ShoppingCart shoppingCart)
//        {
//            _cartRepository = cartRepository;
//            _shoppingCart = shoppingCart;
//        }

//        public IActionResult Index()
//        {

//            return View();
//        }
//        public IActionResult OrderConfirmation()
//        {
//            var service = new Stripe.Checkout.SessionService();
//            Stripe.Checkout.Session session = service.Get(TempData["Session"].ToString());
//            if (session.PaymentStatus == "Paid")
//            {
//                var transaction = session.PaymentIntentId.ToString();

//                return View("Success");
//            }
//            return View();
//        }
//        public IActionResult Success()
//        {
//            return View();
//        }
//        public IActionResult Login()
//        {
//            return View();
//        }
//        public IActionResult Checkout()
//        {
//           List<CartDetail> cartDetails = new List<CartDetail>();
            
//            var domain = "http://localhost:7158/";

//            var options = new Stripe.Checkout.SessionCreateOptions

//            {
//                SuccessUrl = domain + $"Checkout/OrderConfirmation",
//                CancelUrl = domain + $"Checkout/Login",
//                LineItems = new List<SessionLineItemOptions>(),
//                Mode = "payment",
//                //CustomerEmail = "digital@gmail.com

//            };

//            foreach (var item in cartDetails)
//            {
//                var sessionListItem = new SessionLineItemOptions
//                {
//                    PriceData = new SessionLineItemPriceDataOptions
//                    {
//                        UnitAmount = (long)_cartRepository.GetTotalAmount(),
//                        Currency = "cad",
//                        ProductData = new SessionLineItemPriceDataProductDataOptions
//                        {
//                          Name   = item.Book.ToString(),
//                        }


                        

//                    },
//                    Quantity = item.Quantity
//                };
//                options.LineItems.Add(sessionListItem);
//            }
//            var service = new Stripe.Checkout.SessionService();
//            Stripe.Checkout.Session session = service.Create(options);
//            TempData["Session"] = session.Id;

//            Response.Headers.Add("Location", session.Url);
//            return new StatusCodeResult(303);

//        }
//    }
//}
