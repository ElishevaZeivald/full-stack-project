using DAL.DalApi;
using Flights.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class FlightsCrewService : IFlightsCrew
    {
        FlightsContext _FlightCrewsContext;
        public FlightsCrewService(FlightsContext flightsCrewContext)
        {
            _FlightCrewsContext = flightsCrewContext;

        }

        //פונקציה שמחזירה את כל רשימת הנוסעים  
        public List<FlightCrew> GetFlightsCrewList()
        {
            return _FlightCrewsContext.FlightCrews.ToList();
        }
        //פונקציה שמקבלת צוות טיסה ומחזירה באיזה חברת תעופה הוא עובד
        public string GetAirlineName(FlightCrew fc)
        {
            return _FlightCrewsContext.FlightCrews
                .Include(flight => flight.Flight.Airline.AirlineName)
                .FirstOrDefault(f => f.FlightId.Equals(fc.FlightId))
                .ToString();
        }

    }
}
