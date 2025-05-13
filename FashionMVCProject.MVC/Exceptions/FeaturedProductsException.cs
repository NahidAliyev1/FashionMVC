namespace FashionMVCProject.MVC.Exceptions
{
    public class FeaturedProductsException:Exception
    {
        public FeaturedProductsException():base("default exception message")
        {
            
        }
        public FeaturedProductsException(string errormessage):base(errormessage)
        {
            
        }
    }
}
