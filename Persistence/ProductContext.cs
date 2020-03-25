using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace Persistence
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            
        }

    }
}
