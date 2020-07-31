using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Select2.WebApplication.Data;
using Select2.WebApplication.Models;

namespace Select2.WebApplication.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Select2.WebApplication.Data.ApplicationDbContext _context;

        public CreateModel(Select2.WebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
            Customer = new Customer();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IFormFile file = Request.Form.Files.FirstOrDefault();
            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                Customer.Photo = dataStream.ToArray();
            }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
