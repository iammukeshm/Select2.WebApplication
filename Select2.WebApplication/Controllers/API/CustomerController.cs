using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Select2.WebApplication.Data;

namespace Select2.WebApplication.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string term)
        {
            var states = await context.Customers.ToListAsync();
            var data = states.Where(a => a.FirstName.Contains(term, StringComparison.OrdinalIgnoreCase) 
            || a.LastName.Contains(term, StringComparison.OrdinalIgnoreCase)
            || a.City.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList().AsReadOnly();
            return Ok(data);
        }
    }
}