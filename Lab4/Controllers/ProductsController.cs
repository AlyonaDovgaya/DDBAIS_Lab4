using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class ProductsController : Controller
    {
        Lab4Context _dbContext;
        public ProductsController(Lab4Context dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 248)]
        public IActionResult Index()
        {
            return View(_dbContext.Products);
        }
    }
}
