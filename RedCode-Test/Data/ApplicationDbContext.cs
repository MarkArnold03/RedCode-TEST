using System;
using Microsoft.EntityFrameworkCore;
using RedCode_Test.Models;

namespace RedCode_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books{ get; set; }

    }
}

