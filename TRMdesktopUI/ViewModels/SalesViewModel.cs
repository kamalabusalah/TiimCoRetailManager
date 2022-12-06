﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMdesktopUI.ViewModels
{
    public class SalesViewModel:Screen
    {
		private BindingList<string> _products;

		public BindingList<string> Products
		{
			get { return _products; }
			set 
			{ 
				_products = value;
                NotifyOfPropertyChange(() => Products);
            }
		}

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set { _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private string  _itemQuantity;

		public string  ItemQuantity
		{
			get { return _itemQuantity; }

			set { 
				 _itemQuantity = value;
                 NotifyOfPropertyChange(() => ItemQuantity);
                }
		}

        public string  SubTotal
        {
            get
            {
                //ToDo- relace with calculation
                return "$0.00";
            }
           
        }

        public string Tax
        {
            get
            {
                //ToDo- relace with calculation
                return "$0.00";
            }

        }

        public string Total
        {
            get
            {
                //ToDo- relace with calculation
                return "$0.00";
            }

        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                // Make sure something is selected 
                // make sure there is an item Quantity

                return output;
            }

        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromToCart
        {
            get
            {
                bool output = false;
                // Make sure something is selected 
				

                return output;
            }

        }

        public void RemoveFromCartCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                // Make sure something in  the cart


                return output;
            }

        }

        public void CheckOut()
        {

        }

    }
}
