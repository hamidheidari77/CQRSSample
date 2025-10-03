﻿using CQRSExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
