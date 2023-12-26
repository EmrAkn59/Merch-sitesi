using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Entities.Concrete;
using PhoenixMerch.Entities.Dtos;
using PhoenixMerch.WebUI.BasketTransaction.BasketModels;
using PhoenixMerch.WebUI.BasketTransaction;

namespace PhoenixMerch.WebUI.Controllers
{
    public class OrderProcessController : Controller
    {
        private readonly IOrderProcessService _orderProcessService;
        private readonly IBasketTransaction _basketTransaction;
        private readonly IAuthService _authService;
        public OrderProcessController(IOrderProcessService orderProcessService, IBasketTransaction basketTransaction, IAuthService authService)
        {
            _orderProcessService = orderProcessService;
            _basketTransaction = basketTransaction;
            _authService = authService;
        }
        [Authorize]
        public IActionResult OrderProcess()
        {
            BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
            AppUser appUser = _authService.GetUserByUserName(User.Identity.Name).Result;
            foreach (var item in basketDto.BasketItems)
            {
                _orderProcessService.OrderAdd(
                               new OrderProductDto()
                               {
                                   ProductId = item.ProductId,
                                   Price = item.Price,
                                   Quantity = item.Quantity,
                                   CustomerId = appUser.Id
                               });
            }
            basketDto.BasketItems.Clear();
            return View();
        }
    }
}
