using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Select2.WebApplication.Data;
using Select2.WebApplication.Models;

namespace Select2.WebApplication.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Select2.WebApplication.Data.ApplicationDbContext _context;

        public IndexModel(Select2.WebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
