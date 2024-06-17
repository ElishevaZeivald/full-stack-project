using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BLOrders
    {
        public int OrderId { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
