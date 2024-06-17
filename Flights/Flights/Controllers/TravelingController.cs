using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.BLModels;
using Flights.Models;
using DAL.DalApi;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TravelingController : ControllerBase
    {
        // הכונטרולר פונה לבי_אל והב_אל פונה לדאל לכן מזמנים משתנה מסוג בי _אל ןמזריקים בסיטור משתנה מסוג הבי_אל מנג'ר 
        IBLTraveling traveling;
        public TravelingController(BLManager bLTraveling)
        {
            traveling = bLTraveling.BLTraveling;
        }
        #region Get function
        [HttpGet()]
        public ActionResult<List<BLTraveling>> GetTravelingList()
        {
            List<BLTraveling> t = traveling.BLGetTravelingList();
            if (t == null) { return null; }
            return t;
        }
        #endregion

        #region Post function
        [HttpPost]
        public ActionResult<BLTraveling> AddTraveling(BLTraveling travel)
        {
            if (travel == null) { return null; }
            return traveling.BLAddTraveling(travel);
        }
        #endregion

        #region Put function 
        [HttpPut]
        public ActionResult<BLTraveling> UpdateTraveling(BLTraveling travel)
        {
            if (travel == null) { return null; };
            var t = traveling.BLUpdateTraveling(travel);
            return t;
        }
        #endregion

        #region Delete function
        [HttpDelete()]
        public ActionResult<BLTraveling> RemoveTraveling(BLTraveling travel)
        {
            if (travel == null) { throw new ArgumentNullException(); }
            return traveling.BLDeleteTraveling(travel);
        }
        #endregion

    }
}
