using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrganicStore.Models;

namespace OrganicStore.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly CartDbContext _context;

        public DetailsModel(CartDbContext context)
        {
            _context = context;
        }

        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart
                .Include(c => c.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
