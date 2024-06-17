using BL.BLModels;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLWorkers
    {
        //מחזיר רשימה של עובדים
        public List<BLWorkers> BLGetWorkersList();
        //פונקציה שמקבל עובד ומוסיפה אותו לרשימת העובדים
        public BLWorkers BLAddWorker(BLWorkers worker);
        //פונקציה שמוחקת עובד
        public BLWorkers BLRemoveWorker(BLWorkers worker);
        //פונקציה שמעדכנת 
        public BLWorkers BLUpdateWorker(BLWorkers worker);
        //פונקציה שמקבלת רשימת עובדים בתפקיד מסוים
        public List<BLWorkers> BLGetWorkersByRole(string role);
    }
}
