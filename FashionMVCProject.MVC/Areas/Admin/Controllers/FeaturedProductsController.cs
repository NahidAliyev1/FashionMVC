using FashionMVCProject.MVC.Models;
using FashionMVCProject.MVC.Services;
using FashionMVCProject.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FashionMVCProject.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class FeaturedProductsController : Controller
{
    private readonly FeaturedProductsService _featuredProductsService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FeaturedProductsController(IWebHostEnvironment webHostEnvironment)
    {
        _featuredProductsService = new FeaturedProductsService();
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        List<FeaturedProducts> featuredProducts = _featuredProductsService.GetAllFeaturedProducts();
        return View(featuredProducts);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Yeni məhsul əlavə etmək
    [HttpPost]
    public async Task<IActionResult> Create(FeaturedProductsVM model)
    {
        if (ModelState.IsValid)
        {
            string fileName = null;

            // Şəkil faylı varsa
            if (model.ImageFile != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images"); 
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);  
                string filePath = Path.Combine(uploadDir, fileName);

                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);  
                }
            }

            var product = new FeaturedProducts
            {
                Name = model.Name,
                Price = model.Price,
                ShortDescription = model.ShortDescription,
                ImgPath = "/images/" + fileName  
            };

            _featuredProductsService.CreateFeaturedPRoducts(product);  
            return RedirectToAction(nameof(Index));  
        }

        return View(model);  
    }
    [HttpGet]
    public IActionResult Info(int id) 
    {
        FeaturedProducts featuredProducts = _featuredProductsService.GetFeaturedProductsById(id);
        return View(featuredProducts);
    }
    [HttpGet]
    public IActionResult Update(int id) 
    {
        FeaturedProducts featuredProducts = _featuredProductsService.GetFeaturedProductsById(id);
        return View(featuredProducts);
    }
    [HttpPost]
    public IActionResult Update(int id, FeaturedProducts product) 
    {

        _featuredProductsService.UpdateFeaturedPRoducts(id, product);
        return RedirectToAction(nameof(Index));

    }
    [HttpGet]
    public IActionResult Delete(int id) 
    {
        _featuredProductsService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}



