using FashionMVCProject.MVC.Contexts;
using FashionMVCProject.MVC.Exceptions;
using FashionMVCProject.MVC.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FashionMVCProject.MVC.Services;

public class FeaturedProductsService
{
    private readonly AppDbContext _context;
    public FeaturedProductsService()
    {
        _context = new AppDbContext();
    }
    #region Read
    

    public List<FeaturedProducts> GetAllFeaturedProducts() 
    {
        List<FeaturedProducts> featuredProducts = _context.FeaturedProducts.ToList();
        return featuredProducts;


    }
    public FeaturedProducts GetFeaturedProductsById(int id) 
    {
        FeaturedProducts? featuredProducts = _context.FeaturedProducts.Find(id);
        if (featuredProducts is null) 
        {
            throw new FeaturedProductsException($"Databasada {id} tapilmadi");
        }
        {

        }
        return featuredProducts;
    }

    #endregion
    #region Create
    public void CreateFeaturedPRoducts(FeaturedProducts product) 
    {
        _context.FeaturedProducts.Add(product);
        _context.SaveChanges();
    }

    #endregion

    #region Update
    public void UpdateFeaturedPRoducts(int id, FeaturedProducts product) 
    {
        if (id!=product.Id)
        {
            throw new FeaturedProductsException($"IDler ust uste dusmur");
        }
        FeaturedProducts? pr = _context.FeaturedProducts.AsNoTracking().SingleOrDefault(fp =>fp.Id==id);

        if (pr is not null)
        {
            _context.FeaturedProducts.Update(pr);
            _context.SaveChanges();
            
        }
        else
        {
            throw new FeaturedProductsException($"Databasada {id} sahib tapilmadi");
        }
        

    }
    #endregion

    #region Delete
    public void Delete(int id) 
    {
        FeaturedProducts? product = _context.FeaturedProducts.Find(id);
        if (product is not null)
        {
            _context.FeaturedProducts.Remove(product);
            _context.SaveChanges();

        }
        else
        {
            throw new FeaturedProductsException($"Databasada {id} sahib tapilmadi");
        }
    }
    #endregion

}
