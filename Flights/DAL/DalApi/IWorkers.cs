using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IWorkers
    {
        //מחזיר רשימה של עובדים
        public List<Workers> GetWorkersList();
        //פונקציה שמקבל עובד ומוסיפה אותו לרשימת העובדים
        public Workers AddWorker(Workers worker);
        //פונקציה שמוחקת עובד
        public Workers RemoveWorker(Workers worker);
        //פונקציה שמעדכנת 
        public Workers UpdateWorker(Workers worker);
        //פונקציה שמקבלת רשימת עובדים בתפקיד מסוים
        public List<Workers> GetWorkersByRole(string role);

    }
}
