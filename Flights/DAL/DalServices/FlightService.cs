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
    // והזרקנו בתוך הבונהFlightsContext פתחנו מופע מסוג  
    //משווים בין המופע של ההזרקה למופע שפתחנו
    internal class FlightService : IFlights
    {
        FlightsContext _FlightsContext;
        public FlightService(FlightsContext flightsContext)
        {
            _FlightsContext = flightsContext;

        }
        //פונקציות חדשותתתתתת!!!!
        // פונקציה שמציאת טיסות היוצאות בטווח זמן מסוים
        public List<Flight> GetFlightsWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            return _FlightsContext.Flights
                .Where(f => f.DepartureTime >= startTime && f.DepartureTime <= endTime)
                .ToList();
        }
        

        //פונקציה שבודקת איזה טיסות יוצאות באותו יום
        public List<Flight> WhatFlightsDepartThatDay()
        {
            return _FlightsContext.Flights
                .Where(f => f.DepartureTime.Day.Equals(DateTime.Now.Day))
                .ToList();
        }
        //הפונקציה מחזירה את רשימת הנוסעים במטוס 
        List<Flight> IFlights.GetTravelingList()
        {
            return _FlightsContext.Flights
                .Include(t => t.Orders)
                .ThenInclude(o => o.Passenger)
                .ToList();
        }

        //פעולה שמקבלת את הטיסה עם משך הזמן הארוך ביותר
        public Flight GetLongestDurationFlight()
        {
            var longestFlight = _FlightsContext.Flights
                //סדר לפי ירידה
                .OrderByDescending(f => f.FlightDuration)
                .FirstOrDefault();

            return longestFlight;
        }

        //פונקציה שמוסיפה טיסה
        public Flight AddFlifht(Flight flight)
        {
            _FlightsContext.Flights.Add(flight);
            _FlightsContext.SaveChanges();
            return flight;

        }
        public Flight UpdateFlight(Flight flight)
        {
            var fl = _FlightsContext.Flights.FirstOrDefault(f => f.FlightId == flight.FlightId);
            if (fl == null) { return null; }
            fl.FlightDuration = flight.FlightDuration;
            _FlightsContext.SaveChanges();
            return fl;
        }

        public Flight RemoveFlifht(Flight flight)
        {
            var df = _FlightsContext.Flights.FirstOrDefault(f => f.FlightId == flight.FlightId);
            if (df == null) { return null; };
            _FlightsContext.Remove(df);
            _FlightsContext.SaveChanges();
            return df;  
        }

    }
}

