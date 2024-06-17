using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using Flights.Models;
using BL.BLModels;
using DAL.DalApi;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FlightsCrewController : ControllerBase
    {
        // הקונטרולר פונה לבי_אל והב_אל פונה לדאל לכן מזמנים משתנה מסוג בי _אל ןמזריקים בסיטור משתנה מסוג הבי_אל מנג'ר 
        IBLFlightCrew flightCrew;
        public FlightsCrewController(BLManager blFlightsCrew)
        {
            flightCrew = blFlightsCrew.BLFlightCrew;
        }

        #region Get function 
        [HttpGet]
        public ActionResult<List<BLFlightCrew>> GetFlightCrew() 
        {
            List<BLFlightCrew> fl = flightCrew.BLGetFlightsCrewList();
            if (fl == null) { return null; }
            return fl;
        }
        #endregion

        #region Get function 
        [HttpGet("AirlineName")]
        public ActionResult<string> GetAirlineName(BLFlightCrew fc) 
        {
            string ar = flightCrew.BLGetAirlineName(fc);
            if (ar == null) { return null; };
            return ar;
        }
        #endregion
        

    }
}
