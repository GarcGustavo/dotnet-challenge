using challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class ReportingStructureDataSeeder
    {
        private ReportingStructureContext _reportingStructureContext;
        private const String EMPLOYEE_SEED_DATA_FILE = "resources/EmployeeSeedData.json";

        public ReportingStructureDataSeeder(ReportingStructureContext reportingStructureContext)
        {
            _reportingStructureContext = reportingStructureContext;
        }

        public async Task Seed()
        {
            if(!_reportingStructureContext.ReportingStructures.Any())
            {
                List<ReportingStructure> reportingStructures = LoadReportingStructure();
                _reportingStructureContext.ReportingStructures.AddRange(reportingStructures);

                await _reportingStructureContext.SaveChangesAsync();
            }
        }
        private List<ReportingStructure> LoadReportingStructure()
        {
            using (FileStream fs = new FileStream(EMPLOYEE_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Employee> employees = serializer.Deserialize<List<Employee>>(jr);
                List<ReportingStructure> structures = FixUpReferences(employees);

                return structures;
            }
        }

        private List<ReportingStructure> FixUpReferences(List<Employee> employees)
        {
            var employeeIdRefMap = from employee in employees
                                   select new { Id = employee.EmployeeId, EmployeeRef = employee };
            var structures = new List<ReportingStructure>(employees.Count);

            employees.ForEach(employee =>
            {
                if (employee.DirectReports != null)
                {
                    var referencedEmployees = new List<Employee>(employee.DirectReports.Count);
                    employee.DirectReports.ForEach(report =>
                    {
                        var referencedEmployee = employeeIdRefMap.First(e => e.Id == report.EmployeeId).EmployeeRef;
                        referencedEmployees.Add(referencedEmployee);

                        var structure = new ReportingStructure();
                        structure.ReportingStructureId = structures.Count.ToString();
                        structure.Employee = referencedEmployee;
                        structure.NumberOfReports = 0;
                        structures.Add(structure);
                    });

                    employee.DirectReports = referencedEmployees;
                }

            });

            return structures;
        }
    }
}
