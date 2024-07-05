using Microsoft.EntityFrameworkCore;
using MyApiDeneme.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.DAL.Context
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
