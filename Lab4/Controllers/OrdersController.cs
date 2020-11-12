using System.Linq;
using System.Threading.Tasks;
using Lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    public class OrdersController : Controller
    {
        Lab4Context _dbContext;
        public OrdersController(Lab4Context dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 248)]
        public IActionResult Index()
        {
            return View(_dbContext.Orders
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .Take(500));
        }
    }
}
