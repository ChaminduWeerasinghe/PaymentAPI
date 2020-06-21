using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymentAPI.Model
{
    public class payment
    {
        public int paymentID { get; set; }
        public int patientID { get; set; }
        public double ammount { get; set; }
    }
}
