using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
//using SearchView = Android.Widget.SearchView;

using SearchView = Android.Support.V7.Widget.SearchView;
using String = System.String;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;


using Android.Support.V4.Widget;




using Java.Lang;
using Object = Java.Lang.Object;

namespace App1
{
    public class SearchbarActionViewExpandCollaspe: Java.Lang.Object, MenuItemCompat.IOnActionExpandListener
    {


        public IMenu Menu { get; set; }

        public SearchbarActionViewExpandCollaspe (IMenu menu)
        {
            this.Menu = menu;

        }

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {

            setItemsVisibility(Menu, item, true);
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            setItemsVisibility(Menu, item, false);


            return true;
        }


        public void setItemsVisibility(IMenu menu, IMenuItem exception, bool visible)
        {
            for (int i = 0; i < menu.Size(); i++)
            {
                IMenuItem item = menu.GetItem(i);
                if (item != exception)
                {
                    item.SetVisible(visible);
                }
            }
        }

    }
}