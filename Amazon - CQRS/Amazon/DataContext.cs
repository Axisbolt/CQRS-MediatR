﻿using Amazon.Models;
using Microsoft.EntityFrameworkCore; 

namespace Amazon
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}