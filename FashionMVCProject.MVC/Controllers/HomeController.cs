using FashionMVCProject.MVC.Models;
using FashionMVCProject.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FashionMVCProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeaturedProductsService _featuredProductsService;
        public HomeController()
        {
            _featuredProductsService = new FeaturedProductsService();
        }
        public IActionResult Index()
        {
            List<FeaturedProducts> featuredProducts = _featuredProductsService.GetAllFeaturedProducts();

            return View(featuredProducts);
        }
    }
}
