using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IFlights
    {
        //פונקציה שמחזירה  את רשימת הנוסעים בטיסה מסוימת
        public List<Flight> GetTravelingList();
        //פונקציה שבודקת איזה טיסות יוצאות באותו יום
        public List<Flight> WhatFlightsDepartThatDay();
        //הוספת טיסה
        public Flight AddFlifht(Flight flight);
        //פונקציה שמעדכנת יעד טיסה
        public Flight UpdateFlight(Flight flight);
        //פונקציה שמוחקת טיסה
        public Flight RemoveFlifht(Flight flight);
        //פעולה שמקבלת את הטיסה עם משך הזמן הארוך ביותר
        public Flight GetLongestDurationFlight();
        // פונקציה שמציאת טיסות היוצאות בטווח זמן מסוים
        public List<Flight> GetFlightsWithinTimeRange(DateTime startTime, DateTime endTime);
    }
}
