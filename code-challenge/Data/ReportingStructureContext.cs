using challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class ReportingStructureContext : DbContext
    {
        public ReportingStructureContext(DbContextOptions<ReportingStructureContext> options) : base(options)
        {

        }

        //public DbSet<Employee> Employees { get; set; }
        public DbSet<ReportingStructure> ReportingStructures { get; set; }
    }
}
