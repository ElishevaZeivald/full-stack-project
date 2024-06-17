using AutoMapper;
using BL.BLApi;
using BL.BLServices;
using DAL;
using DAL.DalApi;
using Flights.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BL;

public class BLManager
{

    public IBLAirlines BLAirlines { get; set; }
    public IBLFlights BLFlights { get; set; }
    public IBLFlightCrew BLFlightCrew { get; set; }
    public IBLOrders BLOrders { get; set; }
    public IBLTraveling BLTraveling { get; set; }
    public IBLWorkers BLWorkers { get; set; }

    public BLManager()
    {
        // אוביקט שיכיל את כל מחלקות השרות
        ServiceCollection services = new ServiceCollection();
        services.AddAutoMapper(typeof(BlProfile));
        //לבדוק איך לב=סדר את השורה הזו
        //services.AddSingleton<DalManager>(x => new DalManager());
        // מוסיפים לאוסף את אוביקט ממחלקות השרות 
        services.AddSingleton<FlightsContext>();
        services.AddSingleton<IBLAirlines, BLAirlinesServices>();
        services.AddSingleton<IBLFlights, BLFlightsService>();
        services.AddSingleton<IBLFlightCrew, BLFlightCrewService>();
        services.AddSingleton<IBLOrders, BLOrdersServices>();
        services.AddSingleton<IBLTraveling, BLTravelingService>();
        services.AddSingleton<IBLWorkers, BLWorkersService>();
        //כל פעם שרוצים לקבל מופע מסוג עובדים צריך לגשת לאינטרפיס של העובדים 
        //אני צריכה להבין מה קורה כאן
        ServiceProvider provider = services.BuildServiceProvider();
        BLAirlines = provider.GetRequiredService<IBLAirlines>();
        BLFlights = provider.GetRequiredService<IBLFlights>();
        BLFlightCrew = provider.GetRequiredService<IBLFlightCrew>();
        BLOrders = provider.GetRequiredService<IBLOrders>();
        BLTraveling = provider.GetRequiredService<IBLTraveling>();
        BLWorkers = provider.GetRequiredService<IBLWorkers>();
    }
}