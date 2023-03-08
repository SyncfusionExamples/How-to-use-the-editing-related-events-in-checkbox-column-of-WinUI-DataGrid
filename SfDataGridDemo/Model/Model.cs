﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGridDemo
{
    public class OrderInfo : INotifyPropertyChanged
    {
        int orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;
        private decimal unitPrice;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; this.RaisePropertyChanged("OrderID"); }
        }

        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; this.RaisePropertyChanged("CustomerID"); }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; this.RaisePropertyChanged("CustomerName"); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; this.RaisePropertyChanged("Country"); }
        }

        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; this.RaisePropertyChanged("ShipCity"); }
        }
       
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set 
            {
                unitPrice = value; 
                this.RaisePropertyChanged("UnitPrice"); 
            }
        }

        private bool _review;
        public bool Review
        {
            get { return _review; }
            set { _review = value; this.RaisePropertyChanged("Review"); }
        }

        public OrderInfo()
        {

        }

        public OrderInfo(int orderId, string customerName, string country, string customerId, string shipCity, decimal unitPrice)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.UnitPrice = unitPrice;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }       
    }
}