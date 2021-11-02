using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using Android.Net;

namespace App1
{
    [Activity(Theme = "@style/Theme.DesignDemo", Label = "about US")]
    class AboutUsActivity :AppCompatActivity
    {


        ImageButton btnTelegramBehzad;
        ImageButton btnGmailBehzad;
        ImageButton btnGitBehzad;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource 
           
           
                SetContentView(Resource.Layout.AboutUs);
                var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar2);
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                var collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
                collapsingToolbar.Title = "Our Team";

            btnGitBehzad = FindViewById<ImageButton>(Resource.Id.btnGitBehzad);
            btnGmailBehzad = FindViewById<ImageButton>(Resource.Id.btnGmailBehzad);
            btnTelegramBehzad = FindViewById<ImageButton>(Resource.Id.btnTelegramBehzad);


            btnTelegramBehzad.Click += BtnTelegramBehzad_Click;

            btnGmailBehzad.Click += BtnGmailBehzad_Click;
            btnGitBehzad.Click += BtnGitBehzad_Click;
        }

        private void BtnTelegramBehzad_Click(object sender, System.EventArgs e)
        {
            Intent telegram = new Intent(Intent.ActionView, Uri.Parse("https://telegram.me/behzad.p1996"));
            StartActivity(telegram);
        }

        private void BtnGitBehzad_Click(object sender, System.EventArgs e)
        {
            var uri = Uri.Parse("https://github.com/Behzad75");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void BtnGmailBehzad_Click(object sender, System.EventArgs e)
        {
            var email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new string[] {
            "behzad.afb2012@gmail.com"
        });

            email.PutExtra(Intent.ExtraSubject, "Hello Xamarin");
            email.PutExtra(Intent.ExtraText, "Hello Xamarin This is My Test Mail...!");
            email.SetType("message/rfc822");
            StartActivity(email);
        }


    }
}