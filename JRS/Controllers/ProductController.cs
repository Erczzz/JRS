using JRS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JRS.Controllers
{
    public class ProductController : Controller
    {
        IProductDBRepository _repo;
        public ProductController(IProductDBRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllProducts()
        {
            var productList = _repo.GetAllProducts();
            return View(productList);
        }
    }
}
