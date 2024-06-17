using BL.BLModels;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLTraveling
    {
        public List<BLTraveling> BLGetTravelingList();
        public BLTraveling BLAddTraveling(BLTraveling traveling);
        public BLTraveling BLUpdateTraveling(BLTraveling traveling);
        public BLTraveling BLDeleteTraveling(BLTraveling traveling);
    }
}
