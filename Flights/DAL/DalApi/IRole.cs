using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IRole
    {
        //מחזיר רישמה של טייסים
        public List<IRole> pilotsList();

        //מחזיר את הרשימה של הדילים הפנוים
        public List<IRole> avaliableAttendantList();

    }
}
