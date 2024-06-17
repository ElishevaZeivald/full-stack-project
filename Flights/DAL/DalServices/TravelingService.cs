using DAL.DalApi;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    public class TravelingService : ITraveling
    {
        FlightsContext _TravelingContext;
        public TravelingService(FlightsContext travelingContext)
        {
            _TravelingContext = travelingContext; 

        }
        public List<Traveling> GetTravelingList()
        {
            return _TravelingContext.Travelings.ToList();
        }

        public Traveling AddTraveling(Traveling traveling)
        {
            _TravelingContext.Travelings.Add(traveling);
            _TravelingContext.SaveChanges();
            return traveling;
        }

        public Traveling UpdateTraveling(Traveling traveling)
        {
            var t = _TravelingContext.Travelings.FirstOrDefault(tr => tr.PassengerId == traveling.PassengerId);
            if (t == null) { return null; }
            t.ContactInfo = traveling.ContactInfo;
            _TravelingContext.SaveChanges();
            return traveling;
        }

        public Traveling DeleteTraveling(Traveling traveling)
        {
            var dt = _TravelingContext.Travelings.FirstOrDefault(dt => dt.PassengerId == traveling.PassengerId);
            if (dt == null) { return null; };
            _TravelingContext.Remove(dt);
             _TravelingContext.SaveChanges();
            return traveling;


        }
    }
}
