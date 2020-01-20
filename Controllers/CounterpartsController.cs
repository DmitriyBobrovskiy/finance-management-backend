using finance_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace finance_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterpartsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CounterpartsController(DatabaseContext context)
        {
            _context = context;
            context.Fill();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Counterpart>> Get()
        {
            var output = _context.Counterparts;

            return Ok(output);
        }
    }
}