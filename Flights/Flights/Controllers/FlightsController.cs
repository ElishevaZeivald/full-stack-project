using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using Flights.Models;
using BL.BLModels;
using BL.BLServices;
using DAL.DalApi;
using AutoMapper;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FlightsController : ControllerBase
    {

        // הכונטרולר פונה לבי_אל והב_אל פונה לדאל לכן מזמנים משתנה מסוג בי _אל ןמזריקים בסיטור משתנה מסוג הבי_אל מנג'ר 
        IBLFlights flights;
        public FlightsController(BLManager blFlights)
        {
            flights = blFlights.BLFlights;
        }

        #region Get function 
        [HttpGet()]
        public ActionResult<List<BLFlights>> getPassengers()
        {
            List<BLFlights> fl = flights.BLGetTravelingList();
            if (fl == null) { return null; }
            return fl;
        }
        #endregion

        #region Post function 
        [HttpPost]
        public ActionResult<BLFlights> AddNewFlight(BLFlights flight)
        {
            if (flight == null) { throw new ArgumentNullException(); }
            return flights.BLAddFlifht(flight);
        }
        #endregion

        #region Put function 
        [HttpPut()]
        public ActionResult<BLFlights> UpdateFlight(BLFlights flight)
        {
            if (flight == null) { throw new ArgumentNullException(); }
            return flights.BLUpdateFlight(flight);
        }
        #endregion

        #region Delete function 
        [HttpDelete()]
        public ActionResult<BLFlights> DeleteFlight(BLFlights flight)
        {
            if (flight == null) { throw new ArgumentNullException(); }
            return flights.BLRemoveFlifht(flight);
        }
        #endregion

        //פונקציה חדשה
        #region Get function 
        [HttpGet("longest-duration")]
        public ActionResult<BLFlights> GetLongestDurationFlight()
        {
            var longestDurationFlight = flights.BLGetLongestDurationFlight();
            if (longestDurationFlight == null) { return NotFound(); }
            return Ok(longestDurationFlight);
        }
        #endregion

        #region Get function
        [HttpGet("within-time-range")]
        public IActionResult GetFlightsWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            var flightsWithinTimeRange = flights.BLGetFlightsWithinTimeRange(startTime, endTime);
            if (flightsWithinTimeRange == null)
            {
                return NotFound("No flights found within the specified time range.");
            }
            return Ok(flightsWithinTimeRange);
        }
        #endregion




    }
}

