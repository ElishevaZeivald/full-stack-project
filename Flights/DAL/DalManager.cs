using DAL;
using DAL.DalApi;
using DAL.DalServices;
using Flights.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // לבצע הזרקות
    // ליצג את שכבת הדל בצורה מרוכזת
    public class DalManager
    {
        public IWorkers Workers { get; set; }
        public IFlights Flights { get; set; }
        public IAirlines Airlines { get; set; }
        public IOrders Orders { get; set; }
        public ITraveling Traveling { get; set; }

        public DalManager()
        {
            // אוביקט שיכיל את כל מחלקות השרות
            ServiceCollection services = new ServiceCollection();
            // מוסיפים לאוסף את אוביקט ממחלקות השרות
            services.AddSingleton<FlightsContext>();
            services.AddSingleton<IWorkers, WorkersServices>();
            services.AddSingleton<IFlights,FlightService>();
            services.AddSingleton<IAirlines, AirlinesServices>();
            services.AddSingleton<IOrders, OrdersServices>();
            services.AddSingleton<ITraveling, TravelingService>();
            //כל פעם שרוצים לקבל מופע מסוג עובדים צריך לגשת לאינטרפיס של העובדים 
            ServiceProvider provider = services.BuildServiceProvider();
            Workers = provider.GetService<IWorkers>();
            Airlines = provider.GetService<IAirlines>();
            Flights = provider.GetService<IFlights>();
            Orders = provider.GetService<IOrders>();
            Traveling = provider.GetService<ITraveling>();
        }
    }
}

