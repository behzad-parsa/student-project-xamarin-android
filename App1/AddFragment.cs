using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
//using Android.App;
using Android.Content;
using FR.Ganfra.Materialspinner;

using Android.Runtime;
using Android.Util;

using Android.Widget;

namespace App1
{
    public class AddFragment : Fragment
    {
        MaterialSpinner spinner1;
        EditText editTitle;
        EditText editEmail;
        EditText editTel;
        EditText editDes;
        EditText editPrice;
        EditText editFullname;
        EditText editStudy;
        Button btnPostAD;
        //MaterialSpinner spinner2;
        private ArrayAdapter<String> adapter;
        //Spinner spinnerCategory;
        //private static readonly string[] ITEMS = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6" };
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
            // Create your fragment here
        }


        public static AddFragment NewInstance()
        {
            var addFrag = new AddFragment { Arguments = new Bundle() };
            return addFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.AddFragmentLayout, null);

            //spinnerCategory = view.FindViewById<Spinner>(Resource.Id.spinnerCategory);
            IList<string> categoryItem = new List<string>();
            editDes = view.FindViewById<EditText>(Resource.Id.editDes);
            editEmail = view.FindViewById<EditText>(Resource.Id.editEmail);
            editFullname= view.FindViewById<EditText>(Resource.Id.editName);
            editPrice = view.FindViewById<EditText>(Resource.Id.editPrice);
            editStudy= view.FindViewById<EditText>(Resource.Id.editStudy);
            editTel = view.FindViewById<EditText>(Resource.Id.editTel);
            editTitle = view.FindViewById<EditText>(Resource.Id.editTitle);

            btnPostAD = view.FindViewById<Button>(Resource.Id.btnPostAD);


            foreach (var item in DataProcessing.lstCategory)
            {
                categoryItem.Add(item.Name);

            }
            //string[] spinnerItems = new string[] ;
            //n.CopyTo(spinnerItems);




           // ArrayAdapter categoryItem = new ArrayAdapter(Activity, Resource.Layout.support_simple_spinner_dropdown_item, n);
           //// categoryItem.SetDropDownViewResource(Resource.Layout.simp)
           // spinnerCategory.Adapter = categoryItem;





            adapter = new ArrayAdapter<String>(Activity, Resource.Layout.spinner_item , categoryItem);
            adapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
            spinner1 = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerCategory);
            spinner1.Adapter = adapter;
            spinner1.SetPaddingSafe(0, 0, 0, 0);

            //adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleSpinnerItem, ITEMS);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //spinner2 = view.FindViewById<MaterialSpinner>(Resource.Id.spinner2);
            //spinner2.Adapter = adapter;

            btnPostAD.Click += BtnPostAD_Click;

            return view;

        }

        private void BtnPostAD_Click(object sender, EventArgs e)
        {
            Product product = new Product(editTitle.Text, editPrice.Text, editDes.Text, DateTime.Now, new User(editFullname.Text, editStudy.Text, editTel.Text, editEmail.Text), spinner1.SelectedItem.ToString());
            DataProcessing.lstProduct.Add(product);
            Toast.MakeText(Activity, "Added", ToastLength.Long).Show();
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.main, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }


    }
}