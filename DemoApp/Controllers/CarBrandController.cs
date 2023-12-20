using DemoApp.Data;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarBrandController : Controller
    {
        private readonly ILogger<CarBrandController> _logger;
        private readonly ApiDbContext _context;
        public CarBrandController(ILogger<CarBrandController> logger, ApiDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _context.CarBrand.ToListAsync();
            if(data.any)
            return Ok(allDrivers);
        }
    }
}
