using Microsoft.AspNetCore.Mvc;

namespace BookShoppingCartMvcUI.Controllers
{
    public class OrderConfirmationController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public OrderConfirmationController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }


        public async Task<IActionResult> Index()
        {
            var checkout = await _cartRepo.DoCheckout();
            return View();
        }

    }
}
