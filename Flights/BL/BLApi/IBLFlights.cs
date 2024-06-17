using BL.BLModels;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace BL.BLApi
{
    public interface IBLFlights
    {
        public List<BLFlights> BLGetTravelingList();
        public List<BLFlights> BLWhatFlightsDepartThatDay();
        public BLFlights BLAddFlifht(BLFlights flight);
        public BLFlights BLUpdateFlight(BLFlights flight);
        public BLFlights BLRemoveFlifht(BLFlights flight);
        public BLFlights BLGetLongestDurationFlight();
        public List<BLFlights> BLGetFlightsWithinTimeRange(DateTime startTime, DateTime endTime);
    }
}
