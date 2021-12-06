using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IReportingStructureRepository
    {
        ReportingStructure GetById(String id);
        Task SaveAsync();
    }
}