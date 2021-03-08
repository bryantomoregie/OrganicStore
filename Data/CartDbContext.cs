using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganicStore.Models;

    public class CartDbContext : DbContext
    {
        public CartDbContext (DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Cart { get; set; }
    }
