using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IFlightsCrew
    {
        //פונקציה שמחזירה את פרטי הצוות במטוס
        public List<FlightCrew> GetFlightsCrewList();
        //פונקציה שמחזירה את חברת התעופה שהצוות עובד
        public string GetAirlineName(FlightCrew fc);
        
        

    }
}
