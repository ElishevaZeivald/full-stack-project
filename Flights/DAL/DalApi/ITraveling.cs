using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface ITraveling
    {
        //הפונקציה מחזירה רשימה של הנוסעים במטוס
        public List<Traveling> GetTravelingList();
        //פונקציה שמוסיפה נוסע לרשימת הנוסעים
        public Traveling AddTraveling(Traveling traveling);
        //פונקציה שמעדכנת יצירת קשר
        public Traveling UpdateTraveling(Traveling traveling);
        //פונקציה שמוחקת נוסע
        public Traveling DeleteTraveling(Traveling traveling);



    }
}
