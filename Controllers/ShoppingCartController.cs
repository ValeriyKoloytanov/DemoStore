using System.Linq;
using DemoStore.Models;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null) _shoppingCart.AddToCart(selectedProduct);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Decrease(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null) _shoppingCart.DecreaseAmmount(selectedProduct);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null) _shoppingCart.RemoveFromCart(selectedProduct);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearShoppingCart()
        {
            _shoppingCart.ClearCart();

            return RedirectToAction("Index");
        }
    }
}