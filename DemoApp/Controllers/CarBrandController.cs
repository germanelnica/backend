using DemoApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : Controller
    {
        private readonly ILogger<CarBrandController> _logger;
        private readonly ApiDbContext _context;
        public static IConfiguration Configuration { get; private set; }

        public CarBrandController(ILogger<CarBrandController> logger, ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            Configuration = configuration;
            var connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _context.CarBrand.ToListAsync();
            return !data.Any() ? NotFound() : Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await _context.CarBrand.FirstOrDefaultAsync(x => x.Id == id);
            return data is null ? NotFound() : Ok(data);
        }
    }
}
