using DAL.DalApi;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class WorkersServices : IWorkers
    {
        FlightsContext _WorkersContext;
        public WorkersServices(FlightsContext workersContext)
        {
            _WorkersContext = workersContext;

        }
        //פונקציה שמקבלת רשימת עובדים בתפקיד מסוים
        public List<Workers> GetWorkersByRole(string role)
        {
            return _WorkersContext.Workers.Where(w => w.Role == role).ToList();
        }

        public List<Workers> GetWorkersList()
        {
            return _WorkersContext.Workers.ToList();
        }
        //פונקציה שמוסיפה עובד לרשימת העובדים
        public Workers AddWorker(Workers worker)
        {
            _WorkersContext.Workers.Add(worker);
            _WorkersContext.SaveChanges();
            return worker;
        }

        public Workers RemoveWorker(Workers worker)
        {
            _WorkersContext.Workers.Remove(worker);
            _WorkersContext.SaveChanges();
            return _WorkersContext.Workers.FirstOrDefault();
        }

        public Workers UpdateWorker(Workers worker)
        {
            var workers = _WorkersContext.Workers.FirstOrDefault(worker => worker.WorkerId.Equals(worker.WorkerId));
            if (workers == null) { return null; }
            workers.WorkerId  = worker.WorkerId;
            workers.LastName = worker.LastName;
            workers.FirstName = worker.FirstName;
            workers.Role = worker.Role;
            workers.ContactInfo = worker.ContactInfo;
            workers.DateOfEmployment = worker.DateOfEmployment;
            workers.Airlines = worker.Airlines;
            _WorkersContext.SaveChanges();
            return workers;
        }


    }
}
