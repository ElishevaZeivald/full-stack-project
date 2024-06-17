using BL.BLApi;
using BL.BLModels;
using DAL.DalApi;
using DAL;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BL.BLServices
{
    public class BLFlightsService : IBLFlights
    {
        IFlights DalFlights;
        IMapper mapper;
        public BLFlightsService(DalManager dalManager, IMapper m)
        {
            DalFlights = dalManager.Flights;
            mapper = m;
        }

        public List<BLFlights> BLWhatFlightsDepartThatDay()
        {
            var time = DalFlights.WhatFlightsDepartThatDay();
            List<BLFlights> BLTimeList = mapper.Map<List<BLFlights>>(time);

            //foreach (var flights in time)
            //{
            //    BLTimeList.Add(new BLFlights()
            //    {
            //        FlightNumber = flights.FlightId,
            //        AirlineId = flights.AirlineId,
            //        source = flights.ArrivalAirport,
            //        Destination = flights.DepartureAirport,
            //        DepartureTime=flights.DepartureTime,
            //        LandingTime=flights.ArrivalTime,
            //        FlightDuration=flights.FlightDuration,
            //    }); 
            //}

            return BLTimeList;
        }

        public List<BLFlights> BLGetTravelingList()
        {

            var flights = DalFlights.GetTravelingList();
            return mapper.Map<List<BLFlights>>(flights);
        }
        //היה בעיה פו כי קיבלתי אוביקט מסוג DAL והיה צריך לקבל מסוג BL 
        //המרתי את זה בגל שזה מסוג BL ואת ממריה את זה לסוג DAL
        public BLFlights BLAddFlifht(BLFlights flight)
        {
            Flight flightt = mapper.Map<Flight>(flight);
            DalFlights.AddFlifht(flightt);
            return mapper.Map<BLFlights>(flightt);
        }

        public BLFlights BLUpdateFlight(BLFlights flight)
        {
            Flight flightt = mapper.Map<Flight>(flight);
            DalFlights.UpdateFlight(flightt);
            return mapper.Map<BLFlights>(flightt);
        }

        public BLFlights BLRemoveFlifht(BLFlights flight)
        {
            Flight flightt = mapper.Map<Flight>(flight);
            DalFlights.RemoveFlifht(flightt);
            return mapper.Map<BLFlights>(flightt);
        }

        //פונקציות חדשוותתתת!!!!
        public BLFlights BLGetLongestDurationFlight()
        {
            var longestDurationFlight = DalFlights.GetLongestDurationFlight();
            return mapper.Map<BLFlights>(longestDurationFlight);
        }
        public List<BLFlights> BLGetFlightsWithinTimeRange(DateTime startTime, DateTime endTime)
        {
            var flightsWithinTimeRange = DalFlights.GetFlightsWithinTimeRange(startTime, endTime);
            return mapper.Map<List<BLFlights>>(flightsWithinTimeRange);
        }


    }
}
