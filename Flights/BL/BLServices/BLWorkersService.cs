using AutoMapper;
using BL.BLApi;
using BL.BLModels;
using DAL.DalApi;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLServices
{
    public class BLWorkersService : IBLWorkers
    {
        IWorkers dal;
        IMapper mapper;

        public BLWorkersService(IWorkers a, IMapper m)
        {
            dal = a;
            mapper = m;
        }
        public List<BLWorkers> BLGetWorkersByRole(string role)
        {
            var w = dal.GetWorkersByRole(role);
            return mapper.Map<List < BLWorkers >> (w);
        }
        public BLWorkers BLAddWorker(BLWorkers w)
        {
            Workers worker = mapper.Map<Workers>(w);
            dal.AddWorker(worker);
            return mapper.Map<BLWorkers>(worker);

        }

        public List<BLWorkers> BLGetWorkersList()
        {
            var w = dal.GetWorkersList();
            return mapper.Map<List<BLWorkers>>(w);
        }

        public BLWorkers BLRemoveWorker(BLWorkers w)
        {
            Workers worker = mapper.Map<Workers>(w);
            dal.RemoveWorker(worker);
            return mapper.Map<BLWorkers>(worker);
        }

        public BLWorkers BLUpdateWorker(BLWorkers w)
        {
            Workers worker = mapper.Map<Workers>(w);
            dal.UpdateWorker(worker);
            return mapper.Map<BLWorkers>(worker);
        }




    }
}
