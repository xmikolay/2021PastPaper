using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2021
{
    public class Hire
    {
        public int HireID { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal ExtraCharge { get; set; }

        //fk
        public int CarID { get; set; }

        //navigational property, many to one relationship
        public Car Car { get; set; }
    }
}
