using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using SearchView = Android.Support.V7.Widget.SearchView;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
//using Android.App;
using Android.Support.V4.App;


namespace App1
{
    public class AdListFragment : Fragment
    {
        TextView txtToolbarTitle;
        Toolbar toolbar;
        //ListView lstViewProduct;
        private ProductAdapter _productAdapter;
        //List<Product> lstProduct = new List<Product>();
        SearchView searchView;

        private RecyclerView productRecycler;
        private RecyclerView.LayoutManager productRecyclerLayout;
        //private RecyclerView.Adapter _categoryAdapter;
        //private CategoryAdapter _categoryAdapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
            // Create your fragment here

           

        }
        public static AdListFragment NewInstance()
        {
            var addFrag = new AdListFragment { Arguments = new Bundle() };
            return addFrag;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
           
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.AdListFragmentLayout, null);

            //lstViewProduct = view.FindViewById<ListView>(Resource.Id.lstViewProduct);
            productRecycler = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewProduct);
            toolbar = view.FindViewById<Toolbar>(Resource.Id.adListToolbar);
            txtToolbarTitle = view.FindViewById<TextView>(Resource.Id.setAdListTitle);
            
            ((AppCompatActivity)Activity).SetSupportActionBar(toolbar);
            ((AppCompatActivity)Activity).SupportActionBar.SetDisplayShowTitleEnabled(false);
        

            txtToolbarTitle.Text = AdvertiseActivity.categoryFilter;



            productRecyclerLayout = new LinearLayoutManager(Activity);
            productRecycler.SetLayoutManager(productRecyclerLayout);


            if (AdvertiseActivity.categoryFilter == "All")
            {

                _productAdapter = new ProductAdapter(Activity, DataProcessing.lstProduct);
         
                productRecycler.SetAdapter(_productAdapter);

            }
            else if (AdvertiseActivity.categoryFilter != null)
            {


                _productAdapter = new ProductAdapter(Activity, DataProcessing.FilterProductList(AdvertiseActivity.categoryFilter));
      
                productRecycler.SetAdapter(_productAdapter);

            }


            _productAdapter.ItemClick += OnItemClick;

            return view;
        }


        private void OnItemClick(object sender, int position)
        {
            Toast.MakeText(Activity, _productAdapter.GetItemAtPosition(position).Title, ToastLength.Short).Show();

           



        }


        private IMenu _menu;

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.ListToolbar , menu);
            _menu = menu;
            base.OnCreateOptionsMenu(menu, inflater);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
            

                //case Resource.Id.RefreshAction:
                //    Toast.MakeText(this, "Refreshing ... ", ToastLength.Short).Show();
                //    _adapter = new ContactAdapter(this, DataProcessing.allContact, activityType);
                //    lstView.Adapter = _adapter;



                //    return true;

                case Resource.Id.action_search:


                 
                    searchView = item.ActionView as SearchView;
           
                    MenuItemCompat.SetOnActionExpandListener(item, new SearchbarActionViewExpandCollaspe(_menu));

                    searchView.QueryTextChange += SearchView_QueryTextChange;
                    searchView.QueryTextSubmit += SearchView_QueryTextSubmit;



                    return true;




            }
            return base.OnOptionsItemSelected(item);
            
        }
        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            Toast.MakeText(Activity, "Searched For : " + e.Query, ToastLength.Short).Show();
            e.Handled = true;

        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            _productAdapter.Filter.InvokeFilter(e.NewText.ToLower());

        }
    }
}