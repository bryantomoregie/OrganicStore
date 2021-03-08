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
    public class IndexModel : PageModel
    {
        private readonly CartDbContext _context;

        public IndexModel(CartDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.Client).ToListAsync();
        }
    }
}
