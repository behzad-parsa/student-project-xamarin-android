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
using SearchView = Android.Widget.SearchView;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;

//Window.RequestFeature(WindowFeatures.NoTitle);

namespace App1
{
    [Activity(Label = "NIT Contact"  , Icon ="@drawable/icon", Theme = "@style/MyTheme" )]
    public class MainActivity : AppCompatActivity
    {
        private Button btnContact;
        private Button btnSetting;
        private Button btnAboutUs;
        private Button btnAvg;
        private RelativeLayout relativeContact;

        private RelativeLayout relativeMarket;

        private RelativeLayout relativeSetting;

        private RelativeLayout relativeAverage;

        private RelativeLayout relativeAbout;


        //List<Contact> lstContact;



        public static bool isThemeChange = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            UITheme.changeTheme(this, SettingActivity.theme);


            base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);


            //NavigationPage.SetHasNavigationBar(this, false);
            //Contact[] cntList = new Contact[] { new Contact("Mansori","MOsirGoroh","213215" , "1565" , "Man@Yahoo.com" ) , new Contact("Mansori", "MOsirGoroh", "213215", "1565", "Man@Yahoo.com") };




            btnContact = FindViewById<Button>(Resource.Id.btnContact);
                btnAboutUs = FindViewById<Button>(Resource.Id.btnAboutUs);
                btnSetting = FindViewById<Button>(Resource.Id.btnSetting);
                btnAvg = FindViewById<Button>(Resource.Id.btnAvg);

            relativeContact = FindViewById<RelativeLayout>(Resource.Id.relativeContact);
            relativeAbout = FindViewById<RelativeLayout>(Resource.Id.relativeAboutUs);
            relativeAverage = FindViewById<RelativeLayout>(Resource.Id.relativeAverage);
            relativeMarket = FindViewById<RelativeLayout>(Resource.Id.relativeMarket);
            relativeSetting = FindViewById<RelativeLayout>(Resource.Id.relativeSetting);



       


            // ContactActivity cd = new ContactActivity();
            // cd.theme = Resource.Style.MyThemeSecond;

            // public static readonly List<string> phoneNumbers = new List<string>();

            //searchBar = new UISearchbar();


            btnContact.Click += BtnContact_Click;
                
            btnAboutUs.Click += BtnAboutUs_Click;
            btnSetting.Click += BtnSetting_Click1;
            btnAvg.Click += BtnAvg_Click;


            relativeContact.Click += RelativeContact_Click;
            relativeMarket.Click += RelativeMarket_Click;
            relativeAverage.Click += RelativeAverage_Click;
            relativeSetting.Click += RelativeSetting_Click;
            relativeAbout.Click += RelativeAbout_Click;


        }

        private void RelativeAbout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AboutUsActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void RelativeSetting_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SettingActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void RelativeAverage_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AverageActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void RelativeMarket_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AdvertiseActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void RelativeContact_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ContactActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void BtnAvg_Click(object sender, EventArgs e)
        { 
            StartActivity(typeof(AverageActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void BtnSetting_Click1(object sender, EventArgs e)
        {
            StartActivity(typeof(SettingActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AboutUsActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
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


      
        private void BtnContact_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(ContactActivity));
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);
        }


    }
}

