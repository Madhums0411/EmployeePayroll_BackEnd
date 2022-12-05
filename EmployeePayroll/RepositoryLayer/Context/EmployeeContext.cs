using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<EmployeeEntity> EmployeeTable { get; set; }
        public DbSet<EmployeeFormEntity> EmployeeFormTable { get; set; }
    }
}

