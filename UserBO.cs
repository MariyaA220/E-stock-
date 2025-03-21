using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBO
    {
        private int _ID;
        private string _VendorName;
        private string _City;
        private string _Address;
        private string _Mobile;
        private string _Status;
        private string _Product;
        private int _Cost;
        private int _Quantity;
        private int _Total;
        private int _Stock_Count;
        private int _Total_Stock;
        private int _Selling_Price;
        private string _Date;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string VendorName
        {
            get { return _VendorName; }
            set { _VendorName = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        public int Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public int Stock_Count
        {
            get { return _Stock_Count; }
            set { _Stock_Count = value; }
        }

        public int Total_Stock
        {
            get { return _Total_Stock; }
            set { _Total_Stock = value; }
        }

        public int Selling_Price
        {
            get { return _Selling_Price; }
            set { _Selling_Price = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
    }
}
