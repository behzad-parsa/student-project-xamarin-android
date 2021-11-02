using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class Contact { 

        public string Name { get; set; }
        public string Post { get; set; }
        public string DirectTel { get; set; }
        public string ExtensionTel { get; set; }

        public string Email { get; set; }

        public TreeNode<string> ParentMenu { get; set; }
        public Contact(string name, string post, string dTel, string extension , string  email , string parentMenu)
        {
            this.Name = name;
            this.Post = post;
            this.DirectTel = dTel;
            this.ExtensionTel = extension;
            this.Email = email;
            this.ParentMenu = new TreeNode<string>(parentMenu);

        }

        //public static List<Contact> allContact = new List<Contact>();






     //   public int imgResourceId = Resource.Drawable.arrow ;
        
        

        


    }
}