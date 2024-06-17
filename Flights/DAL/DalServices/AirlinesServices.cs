using DAL.DalApi;
using Flights.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DAL.DalServices
{
    internal class AirlinesServices : IAirlines
    {
        FlightsContext _AirlinesContext;
        public AirlinesServices(FlightsContext airlinesContext)
        {
            _AirlinesContext = airlinesContext;
        }

        public List<Airline> Read()
        {
            return _AirlinesContext.Airlines.ToList();
        }

        public List<Airline> ReturnAllTheAirlinesName()
        {
            return _AirlinesContext.Airlines
                .Include(al => al.AirlineName)
                .ToList();
        }

        public Airline AddAirline(Airline airline)
        {
            _AirlinesContext.Airlines.Add(airline);
            _AirlinesContext.SaveChanges();
            return airline;
        }

        public string ChangeContactInfo(Airline airline)
        {
            var ar = _AirlinesContext.Airlines.FirstOrDefault(a => a.AirlineId == airline.AirlineId);
            if (ar == null) { return null; }
            ar.ContactInformation = airline.ContactInformation;
            return ar.ContactInformation;
        }

        public Airline DeleteAirline(int id)
        {
            var da = _AirlinesContext.Airlines.FirstOrDefault(da => da.AirlineId == id);
            if (da == null) { return null; };
            _AirlinesContext.Airlines.Remove(da);
            return da;
        }
    }



}
