using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Compensation
    {
        public Employee Employee { get; set; }
        //Using decimal because floats/doubles cannot accurately represent the base 10 multiples used for money.
        public Decimal Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
