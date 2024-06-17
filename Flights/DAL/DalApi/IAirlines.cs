using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IAirlines
    {
        //פונקציה שמחזירה את רשימת שמות חברות תעופה
        public List<Airline> Read();

        //פונקציה שמקבלת חברה ומדפיסה את כול הטיסות 
        public List<Airline> ReturnAllTheAirlinesName();
        //פונקציה שמוסיפה חברת תעופה
        public Airline AddAirline(Airline airline);
        //פונקציה שמעדכנת את פרטי יצירת הקשר
        public string ChangeContactInfo(Airline airline);
        //מחיקת חברה תעופה
        public Airline DeleteAirline(int id);

        
    }
}
