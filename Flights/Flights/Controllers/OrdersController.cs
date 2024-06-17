using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.BLModels;
using Flights.Models;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        IBLOrders orders;
        public OrdersController(BLManager blOrdersController)
        {
            orders = blOrdersController.BLOrders;
        }

        #region Get function
        [HttpGet()]
        public ActionResult<List<BLOrders>> GetOrdersList()
        {
            List<BLOrders> or = orders.BLGetOrdersList();
            if (or == null) { return null; }
            return or;
        }
        #endregion

        #region Get function
        [HttpGet("OrdersListOfDate")]
        public ActionResult<List<BLOrders>> GetOrdersListOfDate(DateTime date)
        {
            List<BLOrders> or = orders.BLGetOrdersListOfDate(date);
            if (or == null) { return null; }
            return or;
        }
        #endregion

        #region Post function
        [HttpPost()]
        public ActionResult<BLOrders> AddNewOrder(BLOrders order)
        {
            if (order == null) { return null; }
            return orders.BLAddNewOrder(order);
        }
        #endregion

        #region Put function
        [HttpPut()]
        public ActionResult<BLOrders> UpdateOrder(BLOrders order)
        {
            if (order == null) { return null; }
            var or = orders.BLUpdateOrder(order);
            return or;
        }
        #endregion

        #region Delete function
        [HttpDelete()]
        public ActionResult<BLOrders> DeleteOrder(BLOrders order)
        {
            var deleteo = orders.BLDeleteOrder(order);
            if (deleteo == null) { return null; }
            return deleteo;
        }
        #endregion 

    }
}
