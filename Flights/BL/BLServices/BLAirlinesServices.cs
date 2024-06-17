using AutoMapper;
using BL.BLApi;
using BL.BLModels;
using DAL;
using DAL.DalApi;
using Flights.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLServices
{
    public class BLAirlinesServices : IBLAirlines
    {
        //עשינו את זה כך!!!!!!!!!!
        //למה עשינו את זה כך??????
        //IAirlines dal;
        //IMapper mapper;
        //public BLAirlinesServices(IAirlines a, IMapper m)
        //{
        //    dal = a;
        //    mapper = m;
        //}
        //אני עשיתי את זה כך!!!!
        //צריכה לבדוק למה עשיתי פו DalManager dalAirlines למה המנזר הזה??? 
        IAirlines DalAirlines;
        IMapper mapper;

        public BLAirlinesServices(DalManager dalAirlines, IMapper m)
        {
            DalAirlines = dalAirlines.Airlines;
            mapper = m;
        }
        public List<BLAirlines> BLRead()
        {
            //ככה מביאים נתונים מדל
            var list = DalAirlines.Read();
            //פותחים רשימה מסוג בי-אל וממירים את הרשימה מהדל לבי-אל
            List<BLAirlines> BLlist = mapper.Map<List<BLAirlines>>(list);


            // עוברים בלולאה על רשימת הדל וממירים לביאל
            //foreach (var airlines in list)
            //{
            //    BLlist.Add(new BLAirlines()
            //    {
            //        AirlineName = airlines.AirlineName,
            //        ContactInformation = airlines.ContactInformation,
            //        Website = airlines.Website,
            //        Flights = (ICollection<BLFlights>)airlines.Flights
            //    });

            //}
            // הולך לדל ומביא משם את הנתונים מהדטה בייס
            return BLlist;

        }
        public List<String> BLReturnAllTheAirlinesName()
        {
            var list = DalAirlines.ReturnAllTheAirlinesName();// ככה מביאים נתונים,
            List<BLAirlines> BLlist = mapper.Map<List<BLAirlines>>(list);
            //מחזיר את כל השמות שהוא המיר בשורה קודמת
            List<String> names = BLlist.Select(i => i.AirlineName).ToList();
            //// עוברים בלולאה על רשימת הדל וממירים לביאל
            //foreach (var airlines in list)
            //{
            //    BLlist.Add(new BLAirlines()
            //    {
            //        AirlineName = airlines.AirlineName

            //    });
            //}
            return names;
        }
        public BLAirlines BLAddAirline(BLAirlines airline)
        {
            Airline airlinea = mapper.Map<Airline>(airline);
            DalAirlines.AddAirline(airlinea);
            return mapper.Map<BLAirlines>(airlinea);

        }
        //לבדוק האם זה נכון!!!
        public string BLChangeContactInfo(BLAirlines airline)
        {
            Airline airlinea = mapper.Map<Airline>(airline);
            DalAirlines.ChangeContactInfo(airlinea);
            BLAirlines BL = mapper.Map<BLAirlines>(airlinea);
            return BL.ContactInformation;
        }

        public BLAirlines BLDeleteAirline(int id)
        {
            var da = DalAirlines.DeleteAirline(id);
            BLAirlines BL = mapper.Map<BLAirlines>(da);
            return BL;
        }
    }
}
