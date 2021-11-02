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
    class UITheme
    {
        private static int cTheme;



        public const  int BLACK = 0;

        public const  int BLUE = 1;

        public static void changeTheme(Activity activity, int theme)

        {

            cTheme = theme;

            if (cTheme == 1)
            {
                activity.SetTheme(Resource.Style.MyTheme);
            }
            else if  (cTheme == 2)
            {
                activity.SetTheme(Resource.Style.MyThemeSecond);

            }



            
           // activity.Finish();

            


           //// activity.startActivity(new Intent(activity, activity.getClass()));

           // activity.StartActivity(new Intent(activity ,activity.Class)); 


        }

        //public static void onActivityCreateSetTheme(Activity activity)

        //{

        //    switch (cTheme)

        //    {
        //        default:


        //        case BLACK:
        //            MainActivity m = new MainActivity();
        //            m.SetTheme( Resource.Style.MyThemeSecond);
        //            //activity.SetTheme(Resource.Style.MyThemeSecond) ;
        //            //activity.Recreate();

        //            break;

        //        case BLUE:

        //            activity.SetTheme(Resource.Style.MyTheme);
        //            activity.Recreate();

        //            break;

                

        //    }

        //}







    }
}





