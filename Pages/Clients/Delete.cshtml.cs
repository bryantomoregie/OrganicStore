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
    public class DeleteModel : PageModel
    {
        private readonly CartDbContext _context;

        public DeleteModel(CartDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart.FindAsync(id);

            if (Cart != null)
            {
                _context.Cart.Remove(Cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
