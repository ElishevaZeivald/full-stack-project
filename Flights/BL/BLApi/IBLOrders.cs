using BL.BLModels;
using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLOrders
    {     
        //פונקציה שמקבלת הזמנה ומוסיפה לרשימת ההזמנות
        public BLOrders BLAddNewOrder(BLOrders order);
        //הפונקציה מחזירה הזמנות של הטיסות
        public List<BLOrders> BLGetOrdersList();
        //פונקציה שמחזירה רשימת הזמנות בתאריך מסוים
        public List<BLOrders> BLGetOrdersListOfDate(DateTime date);
        // פונקציה שמקבלת הזמנה ובודקת האם היא קימת ברשימת ההזמנות על הצד שכן היא מוחקת היא בודקת ברשימה שיש בדטא_בייס
        public BLOrders BLDeleteOrder(BLOrders order);
        //פונקציה שמעדכנת הזמנה חדשה
        public BLOrders BLUpdateOrder(BLOrders order);
    }
}
