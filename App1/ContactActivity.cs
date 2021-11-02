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

using SearchView = Android.Support.V7.Widget.SearchView;
using String = System.String;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;


using Android.Support.V4.Widget;




using Java.Lang;
using Object = Java.Lang.Object;


namespace App1
{
    [Activity(Label = "Name" , Theme = "@style/MyTheme"  )  ]
    public class ContactActivity : AppCompatActivity  
    {
       
        List<Contact> lstContact;

        ListView lstView;

        SearchView searchView;
        private ContactAdapter _adapter;
        private FloatingActionButton fabMain;
        private View bgFabMenu;
        private static bool prepareListDataFlag = false;
        private DrawerLayout drawerLayout;

        public static bool isThemeChange = false;


        ExpandableListAdapter menuAdapter;
        ExpandableListView expandableList;
        List<ExpandedMenuModel> listDataHeader;
        Dictionary<ExpandedMenuModel, List<String>> listDataChild;
        private  string activityType = "Name";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            UITheme.changeTheme(this, SettingActivity.theme);

            base.OnCreate(savedInstanceState);
                // Window.RequestFeature(WindowFeatures.NoTitle);
                // Create your application here

                SetContentView(Resource.Layout.ContactList);


                lstView = FindViewById<ListView>(Resource.Id.listView1);
                ////////////////////////////searchView = FindViewById<SearchView>(Resource.Id.searchView1);
                fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);
                bgFabMenu = FindViewById<View>(Resource.Id.bg_fab_menu);


                //searchView.SetQueryHint("Search Name");

                if (DataProcessing.addDataFlag == false)
                {
                    DataProcessing.BeginAddData();
                }



                _adapter = new ContactAdapter(this, DataProcessing.allContact, activityType);
                lstView.Adapter = _adapter;


                //-------------------Navigation And  Expandable list----------------------------

                var toolbar = FindViewById<Toolbar>(Resource.Id.contactToolbar);

                //Toolbar will now take on default actionbar characteristics
                SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayShowTitleEnabled(false);



                expandableList = FindViewById<ExpandableListView>(Resource.Id.navigationmenu);
                NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

                if (navigationView != null)
                {
                    navigationView.NavigationItemSelected += OnNavigationItemSelected;
                }



                PrepareListData();

                menuAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild, expandableList);
                
                // setting list adapter
                expandableList.SetAdapter(menuAdapter);

                expandableList.ChildClick += ExpandableList_ChildClick;

            



                //------------------------------------------------------



                
                fabMain.Click += FabMain_Click;

                lstView.ItemClick += LstView_ItemClick;

                ////searchView.QueryTextChange += SearchView_QueryTextChange;
                ////searchView.QueryTextSubmit += SearchView_QueryTextSubmit;
            toolbar.NavigationClick += Toolbar_NavigationClick;

            
        }

        private void Toolbar_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            DrawerLayout mDraw = new DrawerLayout(this);
            mDraw = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mDraw.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
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

        private void FabMain_Click(object sender, EventArgs e)
        {
           // var bundle = new Bundle();


            //bundle.PutString("person", serializeObj);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();


            FilterDialog  filterDialog = new FilterDialog();

            filterDialog.DialogClosed += FilterDialog_DialogClosed;

            //detail.Arguments = bundle;

            filterDialog.Show(transaction, "Filter Dialog");



        }

        private void FilterDialog_DialogClosed(object sender, DialogEventArgs e)
        {
            activityType = e.ReturnValue;

            _adapter = new ContactAdapter(this, DataProcessing.allContact, activityType);
            lstView.Adapter = _adapter;
        }


        private void LstView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var person = _adapter.GetItemAtPosition(e.Position);
            var parentMenuCopy = person.ParentMenu;
            person.ParentMenu = null;
            var personSerializeObj = JsonConvert.SerializeObject(person);
            person.ParentMenu = parentMenuCopy;
           // JsonSerializerSettings df = new JsonSerializerSettings();
            
            //*****For Detail
            //JsonConvert.SerializeObject(person.ParentMenu);
            Intent intent = new Intent(Application.Context, typeof(Detail));
            intent.PutExtra("person", personSerializeObj);
            intent.PutExtra("ParentMenu", parentMenuCopy.Data);
            //intent.PutExtra("parentMenu", JsonConvert.SerializeObject(parentMenuCopy));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);

            //var person = _adapter.GetItemAtPosition(e.Position);
            //person.ParentMenu = null;
            //var serializeObj = JsonConvert.SerializeObject(person);


            //Toast.MakeText(this, person.Name, ToastLength.Short).Show();

            //****For Detail 2******

            //var bundle = new Bundle();


            //bundle.PutString("person", serializeObj);

            //FragmentTransaction transaction = FragmentManager.BeginTransaction();


            //Detail2 detail = new Detail2();


            //detail.Arguments = bundle;

            //detail.Show(transaction, "Detail");


        }


        private void ExpandableList_ChildClick(object sender, ExpandableListView.ChildClickEventArgs e)
        {

            
            var head = menuAdapter.GetHeaderAtPosition(e.GroupPosition);
            var child = menuAdapter.GetChildAtPosition(e.ChildPosition , e.GroupPosition);
            DrawerLayout mDraw = new DrawerLayout(this);
            mDraw = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (child == "All Contact")
            {
                
                _adapter = new ContactAdapter(this, DataProcessing.FilterContactList(head) , activityType);
                lstView.Adapter = _adapter;
                //drawerLayout.CloseDrawers();
                //OnNavigationItemSelected(null, null);
 
                mDraw.CloseDrawers();






            }
            else
            {
                _adapter = new ContactAdapter(this, DataProcessing.FilterContactList(child) , activityType);
                lstView.Adapter = _adapter;
                //drawerLayout.CloseDrawers();
                mDraw.CloseDrawers();

            }



      

        }

   

        private void PrepareListData()
        {
            listDataHeader = new List<ExpandedMenuModel>();
            listDataChild = new Dictionary<ExpandedMenuModel, List<String>>();
            //List<String> submenu = new List<String>();
           // ExpandedMenuModel headerExpand = new ExpandedMenuModel();
            listDataHeader.Clear();
             listDataChild.Clear();
           // submenu.Clear();
            
            prepareListDataFlag = true;
            // try
            // {
            var rootList = DataProcessing.menuList.FindAll(r => r.IsRoot() == true);


            //var rootList2 = DataProcessing.menuList.FindAll(r => r.Data != "All Contacts");
            //var rootList3 = DataProcessing.menuList.FindAll(r => r.IsRoot() == true);
            //submenu.Add("All Contact");

            try
            {

                foreach (var item in rootList)
                {
                   

                    // if (item.IsRoot())
                    // {
                    List<String> submenu = new List<String>();
                    submenu.Add("All Contact");

                    ExpandedMenuModel headerExpand = new ExpandedMenuModel();
                    headerExpand.Name = item.Data;
                    if (item.Data == "All Contacts")
                    {
                        submenu.Clear();
                    }
                 



                    //headerExpand.Image = Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha; ;

                    listDataHeader.Add(headerExpand);

                    for (int i = 0; i < item.Count; i++)
                    {
                        var obj = item.FindInChildren(i);
                        submenu.Add(obj.Data);
                    }

                    //var listB = submenu;
                    listDataChild.Add(listDataHeader.Find(r => r.Name == item.Data), submenu);
                   // submenu.Clear();


                    //}
                    //submenu.Clear();
                    //submenu.Add("All Contact");

                }
            }
            catch(System.Exception e)
            {
                 var msg = e.Message;
               
            }

           // }
           // catch
           // {
               // ;
           // }
            //item1.Name = "heading1";
            //item1.Image = Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha;
            //// Adding data header
            //listDataHeader.Add(item1);

            //ExpandedMenuModel item2 = new ExpandedMenuModel();
            //item2.Name = "heading2";
            //item2.Image = Resource.Drawable.abc_ic_voice_search_api_material;
            //listDataHeader.Add(item2);

            //ExpandedMenuModel item3 = new ExpandedMenuModel();
            //item3.Name = "heading3";
            //item3.Image = Resource.Drawable.abc_ic_menu_share_mtrl_alpha;
            //listDataHeader.Add(item3);

            //ExpandedMenuModel item4 = new ExpandedMenuModel();
            //item4.Name = "heading4";
            //item4.Image = Resource.Drawable.abc_ic_menu_paste_mtrl_am_alpha;
            //listDataHeader.Add(item4);

            //// Adding child data
            //List<String> heading1 = new List<String>();
            //heading1.Add("Submenu of item 1");

            //List<String> heading2 = new List<String>();
            //heading2.Add("Submenu of item 2");
            //heading2.Add("Submenu of item 2");
            //heading2.Add("Submenu of item 2");

            //List<String> heading3 = new List<String>();
            //heading3.Add("Submenu of item 3");
            //heading3.Add("Submenu of item 3");

            //List<String> heading4 = new List<String>();
            //heading4.Add("Submenu of item 4");
            //heading4.Add("Submenu of item 4");

            //listDataChild.Add(listDataHeader[0], heading1);// Header, Child data
            //listDataChild.Add(listDataHeader[1], heading2);
            //listDataChild.Add(listDataHeader[2], heading3);
            //listDataChild.Add(listDataHeader[3], heading4);
        }
        private IMenu _menu;
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            _menu = menu;

            return base.OnCreateOptionsMenu(menu);
            //IMenuItem myActionMenuItem = menu.FindItem(Resource.Id.action_search);
            //searchView = (SearchView)myActionMenuItem.ActionView;
            //LinearLayout s = (LinearLayout) item
            //myActionMenuItem.ExpandActionView();
            //IMenuItemOnActionExpandListener menuItemOnActionExpandListener;
            //menuItemOnActionExpandListener.OnMenuItemActionCollapse(myActionMenuItem);
            //myActionMenuItem.SetOnActionExpandListener(new problis());
            //var h = menuItemOnActionExpandListener.OnMenuItemActionExpand(myActionMenuItem);
            //myActionMenuItem.SetOnActionExpandListener(this);
            //problis n = new problis();
            //n.OnMenuItemActionCollapse(myActionMenuItem);
            //problis n = new problis(
            // myActionMenuItem.SetOnActionExpandListener()
            //MenuItemCompat.SetOnActionExpandListener(myActionMenuItem, new SearchbarActionViewExpandCollaspe());

            //searchView.QueryTextChange += SearchView_QueryTextChange;
            //searchView.QueryTextSubmit += SearchView_QueryTextSubmit;



            //return true;
        }


        
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
     
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
    

                    return true;

                case Resource.Id.RefreshAction:
                    Toast.MakeText(this, "Refreshing ... ", ToastLength.Short).Show();
                    _adapter = new ContactAdapter(this, DataProcessing.allContact , activityType);
                    lstView.Adapter = _adapter;



                    return true;

                case Resource.Id.action_search:


                  
                    searchView = (SearchView)item.ActionView;
                    
                    MenuItemCompat.SetOnActionExpandListener(item, new SearchbarActionViewExpandCollaspe(_menu));

                    searchView.QueryTextChange += SearchView_QueryTextChange;
                    searchView.QueryTextSubmit += SearchView_QueryTextSubmit;

                  

                    return true;

  


            }
            return base.OnOptionsItemSelected(item);
        }

        
        //public void setItemsVisibility(IMenu menu , IMenuItem exception , bool visible)
        //{
        //    for (int i = 0; i < menu.Size() ; i++)
        //    {
        //        IMenuItem item = menu.GetItem(i);
        //        if (item != exception)
        //        {
        //            item.SetVisible(visible);
        //        }
        //    }
        //}

        private void OnNavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            

            var menuItem = e.MenuItem;
            menuItem.SetChecked(!menuItem.IsChecked);
            drawerLayout.CloseDrawers();
        }


        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            Toast.MakeText(this, "Searched For : " + e.Query, ToastLength.Short).Show();
            e.Handled = true;

        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            _adapter.Filter.InvokeFilter(e.NewText.ToLower());

        }


        //public class SearchbarActionViewExpandCollaspe : Java.Lang.Object ,  MenuItemCompat.IOnActionExpandListener
        //{

        //    public void setItemsVisibility(IMenu menu, IMenuItem exception, bool visible)
        //    {
        //        for (int i = 0; i < menu.Size(); i++)
        //        {
        //            IMenuItem item = menu.GetItem(i);
        //            if (item != exception)
        //            {
        //                item.SetVisible(visible);
        //            }
        //        }
        //    }

        //    public bool OnMenuItemActionCollapse(IMenuItem item)
        //    {
         
        //        setItemsVisibility(ContactActivity._menu, item, true);
        //        return true;
        //    }

        //    public bool OnMenuItemActionExpand(IMenuItem item)
        //    {
        //        setItemsVisibility(ContactActivity._menu, item, false);
   

        //        return true;
        //    }
        //}



        //        public void circleReveal(int viewID, int posFromRight, bool containsOverflow, bool isShow)
        //        {
        //            View myView = findViewById(viewID);

        //            int width = myView.getWidth();

        //            if (posFromRight > 0)
        //                width < span class="pl-k">-=</span>(posFromRight<span class="pl-k">*</span>getResources()<span class="pl-k">.</span>getDimensionPixelSize(<span class="pl-smi">R</span><span class="pl-k">.</span>dimen<span class="pl-k">.</span>abc_action_button_min_width_material))<span class="pl-k">-</span>(getResources()<span class="pl-k">.</span>getDimensionPixelSize(<span class="pl-smi">R</span><span class="pl-k">.</span>dimen<span class="pl-k">.</span>abc_action_button_min_width_material)<span class="pl-k">/</span> <span class="pl-c1">2</span>);

        //    if(containsOverflow)
        //        width-=getResources().getDimensionPixelSize(R.dimen.abc_action_button_min_width_overflow_material);

        //        int cx = width;
        //        int cy = myView.getHeight() / 2;

        //        Animator anim;
        //    if(isShow)
        //        anim = ViewAnimationUtils.createCircularReveal(myView, cx, cy, 0, (float)width);
        //    else
        //        anim = ViewAnimationUtils.createCircularReveal(myView, cx, cy, (float) width, 0);

        //    anim.setDuration((long)220);

        //     make the view invisible when the animation is done
        //    anim.addListener(new AnimatorListenerAdapter()
        //        {
        //            @Override
        //        public void onAnimationEnd(Animator animation)
        //            {
        //                if (!isShow)
        //                {
        //                    super.onAnimationEnd(animation);
        //                    myView.setVisibility(View.INVISIBLE);
        //                }
        //            }
        //        });

        //     make the view visible and start the animation
        //    if(isShow)
        //       myView.setVisibility(View.VISIBLE);

        //        start the animation
        //       anim.start();


        //    }






    }

}