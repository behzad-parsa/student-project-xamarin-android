﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class Product
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

       
        public DateTime Date { set; get; }

        public User User { get; set; }


        public string Category { get; set; }

        public Product(string title , string price , string des , DateTime date , User user , string category)
        {
            this.Title = title;
            this.Price = price;
            this.Description = des;
            this.Date = date;
            this.User = user;
            this.Category = category;

            



        }












    }
}