using BL.BLModels;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLAirlines
    {
        public List<BLAirlines> BLRead();
        public List<String> BLReturnAllTheAirlinesName();
        public BLAirlines BLAddAirline(BLAirlines airline);
        public string BLChangeContactInfo(BLAirlines airline);
        public BLAirlines BLDeleteAirline(int id);

    }
}
