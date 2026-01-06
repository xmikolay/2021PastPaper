using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2021
{
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public decimal CostPerDay { get; set; }

        //navigational property, one to many relationship
        public ICollection<Hire> Hires { get; set; }
    }
}
