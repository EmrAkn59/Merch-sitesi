using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixMerch.WebUI.BasketTransaction;
using PhoenixMerch.WebUI.BasketTransaction.BasketModels;

namespace PhoenixMerch.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketTransaction _basketTransaction;

        public BasketController(IBasketTransaction basketTransaction)
        {
            _basketTransaction = basketTransaction;
        }
        
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult Basket()
        {
            BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
            return View(basketDto);
        }

        [HttpGet]
        public IActionResult DecreaseQuantity(int id)
        {
            _basketTransaction.RemoveOrDecrease(id);
            return RedirectToAction("Basket");
        }
        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            _basketTransaction.DeleteItem(id);
            return RedirectToAction("Basket");
        }

        [HttpGet]
        public IActionResult BasketClean()
        {
            _basketTransaction.DeleteBasket();
            return RedirectToAction("Basket");
        }
    }
}
