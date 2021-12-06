using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class ReportingStructureRepository : IReportingStructureRepository
    {
        private readonly ReportingStructureContext _reportingStructureContext;
        private readonly ILogger<IReportingStructureRepository> _logger;

        public ReportingStructureRepository(ILogger<IReportingStructureRepository> logger, ReportingStructureContext reportingStructureContext)
        {
            _reportingStructureContext = reportingStructureContext;
            _logger = logger;
        }

        public ReportingStructure GetById(string id)
        {
            return _reportingStructureContext.ReportingStructures.SingleOrDefault(e => e.Employee.EmployeeId == id) ;
        }

        public Task SaveAsync()
        {
            return _reportingStructureContext.SaveChangesAsync();
        }
    }
}
