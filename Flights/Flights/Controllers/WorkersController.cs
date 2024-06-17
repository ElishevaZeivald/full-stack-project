using BL.BLModels;
using BL;
using DAL.DalApi;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;
using BL.BLApi;
using System.Diagnostics;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WorkersController : ControllerBase 
    {
        IBLWorkers workers;
        public WorkersController(BLManager blWorker)
        {
            workers = blWorker.BLWorkers;
        }
        #region Get function
        [HttpGet()]
        public ActionResult<List<BLWorkers>> GetWorkersList()
        {
            return workers.BLGetWorkersList();
        }
        #endregion

        #region Post function
        [HttpPost()]
        public ActionResult<BLWorkers> AddWorker(BLWorkers worker)
        {
            if (worker == null) { return null; }
            return workers.BLAddWorker(worker);
        }
        #endregion
        
        #region Put function
        [HttpPut()]
        public ActionResult<BLWorkers> UpdateWorker(BLWorkers worker)
        {
            if (worker == null) { throw new ArgumentNullException(); }
            return workers.BLUpdateWorker(worker);
        }
        #endregion

        #region Delete function
        [HttpDelete()]
        public ActionResult<BLWorkers> DeleteWorker(BLWorkers worker)
        {
            if (worker == null) { return null; }
            return workers.BLRemoveWorker(worker);
        }
        #endregion

        [HttpGet()]
        public IActionResult GetWorkersByRole(string role)
        {
            var workersByRole = GetWorkersByRole(role);
            if (workersByRole == null) { return NotFound(); }
            return Ok(workersByRole);
        }

    }
}
