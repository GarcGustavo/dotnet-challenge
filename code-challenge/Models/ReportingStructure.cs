using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class ReportingStructure
    {
        [Key]
        public string ReportingStructureId { get; set; }
        public Employee Employee { get; set; }
        public int NumberOfReports 
        {
            get
            {
                var result = 0;

                //TODO: employee returning as null instead of current Eployee object, if is temporary fix for debugging
                if (Employee != null)
                {
                    var queue = new Queue<Employee>();
                    queue.Enqueue(Employee);

                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        result++;

                        if (null != current.DirectReports)
                        {
                            foreach (Employee inner in current.DirectReports)
                            {
                                queue.Enqueue(inner);
                            }
                        }
                    }
                }

                return result;
            }
            set
            {

            }
        }
    }
}
