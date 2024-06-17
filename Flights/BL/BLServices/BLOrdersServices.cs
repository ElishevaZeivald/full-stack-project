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
    public class BLOrdersServices : IBLOrders
    {
        IOrders dal;
        IMapper mapper;

        public BLOrdersServices(IOrders o, IMapper m)
        {
            dal = o;
            mapper = m;
        }
        public BLOrders BLAddNewOrder(BLOrders order)
        {
            Order orderr = mapper.Map<Order>(order);
            dal.AddNewOrder(orderr);
            return mapper.Map<BLOrders>(orderr);   
        }

        public BLOrders BLDeleteOrder(BLOrders order)
        {
            Order orderr = mapper.Map<Order>(order);
            dal.DeleteOrder(orderr);
            return mapper.Map<BLOrders>(orderr);
        }

        public List<BLOrders> BLGetOrdersList()
        {
            var list = dal.GetOrdersList();
            List<BLOrders> BLlist = mapper.Map<List<BLOrders>>(list);
            return BLlist;
        }

        public List<BLOrders> BLGetOrdersListOfDate(DateTime date)
        {
            var list = dal.GetOrdersListOfDate(date);
            List<BLOrders> BLlist = mapper.Map<List<BLOrders>>(list);
            return BLlist;
        }
        public BLOrders BLUpdateOrder(BLOrders order)
        {
            Order orderr = mapper.Map<Order>(order);
            dal.UpdateOrder(orderr);
            return mapper.Map<BLOrders>(orderr);
        }
    }
}

