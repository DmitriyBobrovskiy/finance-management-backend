using finance_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace finance_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccountsController(DatabaseContext context)
        {
            _context = context;
            context.Fill();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var output = _context.Accounts
                .Include(account => account.AccountType)
                .Include(account => account.Currency);

            return Ok(output);
        }
    }
}