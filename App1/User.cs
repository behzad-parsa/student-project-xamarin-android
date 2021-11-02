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
    public class User
    {

        public string Name { get; set; }
        public string Tel { get; set; }

        public string Email { get; set; }
        
        public string Study { get; set; }

        public User (string name ,string study ,string Tel , string Email)
        {
            this.Name = name;
            this.Study = study;
            this.Tel = Tel;
            this.Email = Email;

        }
       






    }
}