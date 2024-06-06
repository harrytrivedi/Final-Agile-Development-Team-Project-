using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class OrderCollection
    {
        private List<Order> orders = new List<Order>();

        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public int Count
        {
            get { return orders.Count; }
        }

        public Order this[int index]
        {
            get { return orders[index]; }
            set { orders[index] = value; }
        }

        public void Add(Order order)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", order.Username);
            db.AddParameter("@MedName", order.MedName);
            db.AddParameter("@Quantity", order.Quantity);
            db.AddParameter("@Price", order.Price);
            db.Execute("spAddOrder");
        }

        public void Remove(int orderId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@OrderId", orderId);
            db.Execute("spDeleteOrder");
        }

        public void Update(Order order)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@OrderId", order.OrderId);
            db.AddParameter("@Username", order.Username);
            db.AddParameter("@MedName", order.MedName);
            db.AddParameter("@Quantity", order.Quantity);
            db.AddParameter("@Price", order.Price);
            db.Execute("spUpdateOrder");
        }

        public void LoadOrders()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllOrders");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    Username = row["Username"].ToString(),
                    MedName = row["MedName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"])
                };
                orders.Add(order);
            }
        }

        public void LoadOrdersByUsername(string username)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", username);
            db.Execute("spGetOrdersByUsername");
            DataTable dt = db.DataTable;

            orders.Clear(); // Clear existing orders before loading new ones

            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    Username = row["Username"].ToString(),
                    MedName = row["MedName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"])
                };
                orders.Add(order);
            }
        }


        public Order FindById(int orderId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@OrderId", orderId);
            db.Execute("spGetOrder");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new Order
                {
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    Username = row["Username"].ToString(),
                    MedName = row["MedName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"])
                };
            }
            return null;
        }
    }
}
