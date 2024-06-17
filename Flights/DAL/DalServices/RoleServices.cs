using DAL.DalApi;
using Flights.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class RoleServices : IRole
    {
        FlightsContext _AirlinesContext;
        public RoleServices(FlightsContext airlinesContext)
        {
            _AirlinesContext = airlinesContext;
        }

        public List<IRole> avaliableAttendantList()
        {
            throw new NotImplementedException();
        }

        public List<IRole> pilotsList()
        {
            throw new NotImplementedException();
        }
        //תיקוןןןןן
        //public List<IRole> pilotsList()
        //{
        //    return _AirlinesContext.Roles
        //        .Include(p=>p.FlightCrews.)
        //        .ToList();
        //}
        //public List<IRole> avaliableAttendantList()
        //{
        //    return _AirlinesContext.Roles
        //         .Where(pilot => pilot.פנוי == true)
        //         .Include()
        //         .ToList();

        //}

    }
}
