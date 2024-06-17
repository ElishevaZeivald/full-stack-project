using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IOrders
    {
        //הפונקציה מחזירה הזמנות של הטיסות
        public List<Order> GetOrdersList();
        //פונקציה שמחזירה רשימת הזמנות בתאריך מסוים
        public List<Order> GetOrdersListOfDate(DateTime dateTime);
        //פונקציה שמקבלת הזמנה ומוסיפה לרשימת ההזמנות
        public Order AddNewOrder(Order order);
        // פונקציה שמקבלת הזמנה ובודקת האם היא קימת ברשימת ההזמנות על הצד שכן היא מוחקת היא בודקת ברשימה שיש בדטא_בייס
        public Order DeleteOrder(Order order);
        //פונקציה שמעדכנת כיסה בהזמנה
        public Order UpdateOrder(Order order);
        

    }
}
