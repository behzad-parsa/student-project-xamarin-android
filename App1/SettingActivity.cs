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

namespace App1
{
    [Activity(Label = "SettingActivity" , Theme = "@style/MyTheme")]
    public class SettingActivity : AppCompatActivity
    {

        RadioButton Theme1;
        RadioButton Theme2;
        Button btnSet;
        public static int theme;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            UITheme.changeTheme(this, SettingActivity.theme);
           
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Setting);


            Theme1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            Theme2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            btnSet = FindViewById<Button>(Resource.Id.button1);

            var toolbar = FindViewById<Toolbar>(Resource.Id.settingToolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayShowTitleEnabled(false);



            btnSet.Click += BtnSet_Click;
            toolbar.NavigationClick += Toolbar_NavigationClick;

        }

        private void Toolbar_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            this.Finish();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            MainActivity.isThemeChange = true;
            ContactActivity.isThemeChange = true;
            Detail.isThemeChange = true;
            AverageActivity.isThemeChange = true;
            AdvertiseActivity.isThemeChange = true;
            if (Theme1.Checked)
            {
                
                theme = 1;      

            }
            else if (Theme2.Checked)
            {
                theme = 2;

            }
            Recreate();
        }
    }
}