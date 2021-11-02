using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;


namespace App1
{
    [Activity(Theme = "@style/Theme.Splash", NoHistory = true , MainLauncher = true)]
    class SplashActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() =>
            {
                Task.Delay(8000);
            });

            startupWork.ContinueWith(t =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }



    }
}