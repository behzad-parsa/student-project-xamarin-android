using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;




namespace App1
{
    public class CategoryFragment : Fragment
    {
        private RecyclerView categoryRecycler;
        private RecyclerView.LayoutManager categoryRecyclerLayout;
        //private RecyclerView.Adapter _categoryAdapter;
        private CategoryAdapter _categoryAdapter;
        //private List<Category> lstCategory = new List<Category>();
        //BottomNavigationView bottomNavigation;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static CategoryFragment NewInstance()
        {
            var categoryFragment = new CategoryFragment { Arguments = new Bundle() };
            return categoryFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //Toast.MakeText(Activity, "dd", ToastLength.Short).Show();
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.CategoryFragmentLayout, null);

            //lstCategory.Add(new Category("All", Resource.Drawable.claptop));
            //lstCategory.Add(new Category("Food", Resource.Drawable.claptop));
            //lstCategory.Add(new Category("Computer", Resource.Drawable.claptop));
            //lstCategory.Add(new Category("Prject", Resource.Drawable.claptop));
            //lstCategory.Add(new Category("Book", Resource.Drawable.claptop));
            //lstCategory.Add(new Category("Hellop", Resource.Drawable.claptop));

            categoryRecycler = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewCategory);
            //bottomNavigation = view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);


            //DataProcessing.AddCategory();
            categoryRecyclerLayout = new GridLayoutManager(Activity, 2);
            categoryRecycler.SetLayoutManager(categoryRecyclerLayout);

            _categoryAdapter = new CategoryAdapter(Activity,DataProcessing.lstCategory);
            _categoryAdapter.ItemClick += OnItemClick;
            categoryRecycler.SetAdapter(_categoryAdapter);


            

            return view;
        }

        //private void _categoryAdapter_ItemClick(object sender, int e)
        //{
        //    Toast.MakeText(Activity, "dd", ToastLength.Short).Show();
        //}

        private void OnItemClick(object sender, int position)
        {
            //Toast.MakeText(Activity, _categoryAdapter.GetItemAtPosition(position).Name, ToastLength.Short).Show();

            AdvertiseActivity.categoryFilter = _categoryAdapter.GetItemAtPosition(position).Name;
            //SupportFragmentManager.BeginTransaction()
            //    .Replace(Resource.Id.content_frame, AdListFragment.NewInstance())
            //    .Commit();

            //var trans = new FragmentActivity().SupportFragmentManager.BeginTransaction();
            //BottomNavigationViewUtils.SetShiftMode(bottomNavigation, true, true);
            //AdvertiseActivity.LoadFragmentstatic(AdListFragment , )

            //LoadFragment(Resource.Id.navAd);
            // bottomNavigation.M
            // bottomNavigation.Menu.FindItem(Resource.Id.navAd).SetChecked(true);
            // bottomNavigation.Menu.GetItem(Resource.Id.navAd).SetChecked(true);
            //bottomNavigation.setsel
            //View view = bottomNavigation.FindViewById(Resource.Id.navAd);
            //view.performClick();
            //view.PerformClick();
            AdvertiseActivity._bottomNavigation.Menu.FindItem(Resource.Id.navAd).SetChecked(true);
            FragmentTransaction f = FragmentManager.BeginTransaction();
            //BottomNavigationViewUtils.SetShiftMode(bottomNavigation, true, true);
            //b//ottomNavigation.Menu.FindItem(Resource.Id.navAd);

            
            f.Replace(Resource.Id.content_frame, AdListFragment.NewInstance());
            f.AddToBackStack(null);
            f.Commit();
            


        }
       
    }
}