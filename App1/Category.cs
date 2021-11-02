using System;
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
    public class Category
    {
        public string Name { get; set; }

        public int IconID { get; set; }


        public Category(string name , int iconid)
        {

            this.Name = name;
            this.IconID = iconid;

        }




    }
}