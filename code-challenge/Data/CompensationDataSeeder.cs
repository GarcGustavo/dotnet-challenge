using challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class CompensationDataSeeder
    {
        /*
        private CompensationDataSeeder _CompensationContext;
        private const String Compensation_SEED_DATA_FILE = "resources/CompensationSeedData.json";

        public CompensationDataSeeder(CompensationContext CompensationContext)
        {
            _CompensationContext = CompensationContext;
        }

        public async Task Seed()
        {
            if(!_CompensationContext.Compensations.Any())
            {
                List<Compensation> Compensations = LoadCompensations();
                _CompensationContext.Compensations.AddRange(Compensations);

                await _CompensationContext.SaveChangesAsync();
            }
        }

        private List<Compensation> LoadCompensations()
        {
            using (FileStream fs = new FileStream(Compensation_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Compensation> Compensations = serializer.Deserialize<List<Compensation>>(jr);
                FixUpReferences(Compensations);

                return Compensations;
            }
        }

        private void FixUpReferences(List<Compensation> Compensations)
        {
            var CompensationIdRefMap = from Compensation in Compensations
                                select new { Id = Compensation.CompensationId, CompensationRef = Compensation };

            Compensations.ForEach(Compensation =>
            {
                
                if (Compensation.DirectReports != null)
                {
                    var referencedCompensations = new List<Compensation>(Compensation.DirectReports.Count);
                    Compensation.DirectReports.ForEach(report =>
                    {
                        var referencedCompensation = CompensationIdRefMap.First(e => e.Id == report.CompensationId).CompensationRef;
                        referencedCompensations.Add(referencedCompensation);
                    });
                    Compensation.DirectReports = referencedCompensations;
                }
            });
        }
        */
    }
}
