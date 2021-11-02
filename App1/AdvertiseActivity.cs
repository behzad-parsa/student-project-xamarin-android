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
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;

namespace App1
{
    [Activity(Label = "AdvertiseActivity", Theme = "@style/MyTheme")]
    public class AdvertiseActivity : AppCompatActivity
    {

        public static bool isThemeChange = false;
        //private ProductAdapter _adapter;
        //List<Product> lstProduct = new List<Product>();
        //ListView lstViewProduct;
        public static string categoryFilter = "All";
            
       Toolbar toolbar;
        BottomNavigationView bottomNavigation;
        public static BottomNavigationView _bottomNavigation;
        TextView txtToolbar;
       // private int navIdSelected;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            UITheme.changeTheme(this, SettingActivity.theme);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Advertise);

            toolbar = FindViewById<Toolbar>(Resource.Id.advertiseToolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            toolbar.Visibility = ViewStates.Gone;
            //if (toolbar != null)
            //{
               
            //    SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            //    SupportActionBar.SetHomeButtonEnabled(false);

            //}

            //lstViewProduct = FindViewById<ListView>(Resource.Id.lstViewProduct);


            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            _bottomNavigation = bottomNavigation;
            txtToolbar = FindViewById<TextView>(Resource.Id.setAdvertiseTitle);

            if (DataProcessing.addDataMarketFlag == false)
            {
                DataProcessing.BeginAddProductList();

            }

            

            //lstProduct.Add(new Product("Jozve", "20000", "Foooori", new DateTime(2015, 05, 6) , new User("Behzad" , "Computer" , "123546" , "Behzas@yahoo.com") , "Book"));

            //_adapter = new ProductAdapter(this, lstProduct);
            //lstViewProduct.Adapter = _adapter;








            toolbar.NavigationClick += Toolbar_NavigationClick;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;




            LoadFragment(Resource.Id.navCategory);


        }
        
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
           // navIdSelected = e.Item.ItemId;
            
        }

        private void Toolbar_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            this.Finish();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (isThemeChange)
            {
                isThemeChange = false;
                Recreate();

            }
        }
        

        private void LoadFragment(int id)
        {
            BottomNavigationViewUtils.SetShiftMode(bottomNavigation, true, true);
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.navCategory:
                    fragment = CategoryFragment.NewInstance();
                    txtToolbar.Text = "Category";
                    //toolbar.Visibility = ViewStates.Visible;
       
                    break;
                case Resource.Id.navAd:
                    fragment = AdListFragment.NewInstance();
                    txtToolbar.Text = AdvertiseActivity.categoryFilter;
                    //toolbar.Visibility = ViewStates.Visible;
                    break;
                case Resource.Id.navAdd:
                    fragment = AddFragment.NewInstance();
                    txtToolbar.Text = "Add";
                    //toolbar.Visibility = ViewStates.Visible;

                    break;
            }


                if (fragment == null)
                    return;
                

                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, fragment)
                    .Commit();
            }
        //public static void LoadFragmentstatic(int id , BottomNavigationView bottomNavigation)
        //{
        //    BottomNavigationViewUtils.SetShiftMode(bottomNavigation, true, true);
        //    Android.Support.V4.App.Fragment fragment = null;
        //    switch (id)
        //    {
        //        case Resource.Id.navCategory:
        //            fragment = CategoryFragment.NewInstance();


        //            break;
        //        case Resource.Id.navAd:
        //            fragment = AdListFragment.NewInstance();

        //            break;
        //        case Resource.Id.navAdd:
        //            fragment = AddFragment.NewInstance();


        //            break;
        //    }


        //    if (fragment == null)
        //        return;


        //    //SupportFragmentManager.BeginTransaction()
        //    //    .Replace(Resource.Id.content_frame, fragment)
        //    //    .Commit();
        //}

    }
}