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
    public class BLFlightCrewService : IBLFlightCrew
    {
        IFlightsCrew dal;
        IMapper mapper;

        public BLFlightCrewService(IFlightsCrew f, IMapper m)
        {
            dal = f;
            mapper = m;
        }
        public List<BLFlightCrew> BLGetFlightsCrewList()
        {
            var list = dal.GetFlightsCrewList();
            var BLlist = mapper.Map<List<BLFlightCrew>>(list);
            return BLlist;
        }
        public string BLGetAirlineName(BLFlightCrew fc)
        {
            FlightCrew flightCrew = mapper.Map<FlightCrew>(fc);
            dal.GetAirlineName(flightCrew);// ככה מביאים נתונים,
            return mapper.Map<string>(flightCrew);
        }

    }
}