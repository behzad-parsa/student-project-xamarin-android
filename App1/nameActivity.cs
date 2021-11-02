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
using Newtonsoft.Json;

namespace App1
{
    [Activity(Label = "Names")]
    public class nameActivity : ListActivity
    {
        string[] items;
        List<Contact> lstContact;
        LinearLayout ln;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Create your application here
            SearchView searchView = new SearchView(this);

            searchView.SetX(0);
            searchView.SetY(0);



            //\ Contact[] cntList = new Contact[] { new Contact("Mansori","MOsirGoroh","213215" , "1565" , "Man@Yahoo.com" ) , new Contact("Mansori", "MOsirGoroh", "213215", "1565", "Man@Yahoo.com") };
            //lstContact = new List<Contact>();
            //lstContact.Add(new Contact("Mansori", "MOsirGoroh", "213215", "1565", "Man@Yahoo.com"));
            //lstContact.Add(new Contact("Vailg", "MOsirGoroh", "213215", "1565", "Asabi@Yahoo.com"));
            items = new string[2];
            int i = 0;

            foreach (var item in lstContact)
            {
                items[i] = item.Name;

                i++;
            }

            //var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);




        }
        
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = items[position];
            var person = lstContact.Find(r => r.Name == t);
            //Android.Widget.Toast.MakeText(this, person.Email, Android.Widget.ToastLength.Short).Show();
            //StartActivity(typeof(Detail));

            Intent Intent = new Intent(Application.Context, typeof(Detail));
            Intent.PutExtra("person", JsonConvert.SerializeObject(person));
            
           StartActivity(Intent);

        }
    }
}