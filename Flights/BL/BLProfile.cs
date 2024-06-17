using AutoMapper;
using BL.BLModels;
using Flights.Models;

namespace BL
{
    public class BlProfile : Profile
    {
            public BlProfile()
        {

            CreateMap<Airline, BLAirlines>()
                //.ForMember(dest => dest.AirlineId, opt => opt.Ignore())
                //.ForMember(dest => dest.WorkerId, opt => opt.Ignore())
                //.ForMember(dest => dest.Worker, opt => opt.Ignore())
                .ReverseMap();//הוא ממיר משני הצדדים

            CreateMap<FlightCrew, BLFlightCrew>()
                //.ForMember(dest => dest.Flight, opt => opt.Ignore())
                //.ForMember(dest => dest.Role, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BLFlights, Flight>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightNumber))
                .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.source))
                .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.Destination))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.LandingTime))
                .ForMember(dest => dest.Airline, opt => opt.Ignore())
                .ForMember(dest => dest.FlightCrews, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BLOrders, Order>()
                .ForMember(dest => dest.Flight, opt => opt.Ignore())
                .ForMember(dest => dest.Passenger, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BlRoles, Role>()
                .ForMember(dest => dest.RoleId, opt => opt.Ignore())
                .ForMember(dest => dest.FlightCrews, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BLTraveling, Traveling>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BLWorkers, Workers>()
                .ForMember(dest => dest.Airlines, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}

