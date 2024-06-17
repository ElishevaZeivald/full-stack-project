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
    public class BLTravelingService : IBLTraveling
    {
        ITraveling dal;
        IMapper mapper;

        public BLTravelingService(ITraveling t, IMapper m)
        {
            dal = t;
            mapper = m;
        }

        public List<BLTraveling> BLGetTravelingList()
        {
            var t = dal.GetTravelingList();
            return mapper.Map<List<BLTraveling>>(t);
        }


        public BLTraveling BLAddTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.AddTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);

        }

        public BLTraveling BLUpdateTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.UpdateTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);
            
        }

        public BLTraveling BLDeleteTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.DeleteTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);

        }
    }
}
