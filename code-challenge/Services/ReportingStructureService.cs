using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IReportingStructureRepository _reportRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IReportingStructureRepository reportRepository)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }

        public ReportingStructure GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _reportRepository.GetById(id);
            }

            return null;
        }
    }
}
