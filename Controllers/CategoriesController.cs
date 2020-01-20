using finance_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace finance_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
            context.Fill();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var output = _context.Categories
                .Include(category => category.Icon);

            return Ok(output);
        }
    }
}