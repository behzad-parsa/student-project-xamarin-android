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
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;

using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;



using Android.Support.V4.Widget;
using Android.Animation;

namespace App1
{
    //@android:style/Theme.Material.Light.Voice
    [Activity(Label = "Detail" ,  Theme = "@style/MyTheme")]

    public class Detail : AppCompatActivity
    {
        //LinearLayout ln;
        Contact person;
       // TreeNode<string> parentMenu;
        TextView txtName;
        TextView txtEmail;
        TextView txtDTel;
        TextView txtETel;
        TextView txtPost;
        TextView txtParentPath;
        TextView txtChildPath;
        LinearLayout lnParent;
        LinearLayout lnChild;
        private static bool isOneDirect;
        private static bool isOneInternal;

        private static bool isNullDirect;
        private static bool isNullInternal;

        View vFabDial;
        public static bool IsFabOpen;
        //private FloatingActionButton fabDial;
        private FloatingActionButton fabPlus;
        private FloatingActionButton fabInPhone;
        private FloatingActionButton fabDPhone;

        public static bool isThemeChange = false;
        //ListView lstViewETel;
        //ArrayAdapter<string> adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            UITheme.changeTheme(this, SettingActivity.theme);
         
            base.OnCreate(savedInstanceState);
                // Window.RequestFeature(WindowFeatures.NoTitle);
                // Create your application here
                SetContentView(Resource.Layout.Detail);


                // lstViewETel = FindViewById<ListView>(Resource.Id.lstViewETel);

                person = JsonConvert.DeserializeObject<Contact>(Intent.GetStringExtra("person"));
            string parentMenuData = Intent.GetStringExtra("ParentMenu");
            TreeNode<string> parentMenuObj = new TreeNode<string>(parentMenuData);
            person.ParentMenu = parentMenuObj;
            //var parentMenu = JsonConvert.DeserializeObject<TreeNode<string>>(Intent.GetStringExtra("parentMenu"));
            // person.ParentMenu = parentMenu;

            txtParentPath = FindViewById<TextView>(Resource.Id.txtParent);
            txtChildPath = FindViewById<TextView>(Resource.Id.txtChild);
            lnParent = FindViewById<LinearLayout>(Resource.Id.linearLayoutParent);
            lnChild = FindViewById<LinearLayout>(Resource.Id.linearLayoutChild);
            

                //+
                fabPlus = FindViewById<FloatingActionButton>(Resource.Id.fab_dialpad);
                vFabDial = FindViewById<View>(Resource.Id.bg_fab_menu);
                fabInPhone = FindViewById<FloatingActionButton>(Resource.Id.fab_IPhone);
                fabDPhone = FindViewById<FloatingActionButton>(Resource.Id.fab_DPhone);




                txtName = FindViewById<TextView>(Resource.Id.txtName);
                txtEmail = FindViewById<TextView>(Resource.Id.txtEmail);
                txtPost = FindViewById<TextView>(Resource.Id.txtPost);
                txtDTel = FindViewById<TextView>(Resource.Id.txtDTel);
                txtETel = FindViewById<TextView>(Resource.Id.txtETel);

            var rootMenu = DataProcessing.menuList.Find(r => r.Data == person.ParentMenu.Data);
            if (rootMenu.IsRoot())
            {
                txtParentPath.Text = rootMenu.Data;
                lnChild.Visibility = ViewStates.Gone;

            }
            else
            {
                lnChild.Visibility = ViewStates.Visible;
                //var parentMenu = person.ParentMenu;
                while (!rootMenu.IsRoot())
                {
                    rootMenu = rootMenu.Parent;

                }

                txtParentPath.Text = rootMenu.Data;
                txtChildPath.Text = person.ParentMenu.Data;




            }

            //if (rootMenu.Count > 0) 
            //{
            //    // View add = View.Inflate()


            //    //lnChild.Visibility = ViewStates.Visible;
            //    txtChildPath.Text = person.ParentMenu.Data;

            //    //LinearLayout ln = new LinearLayout(lnParent.Context);
            //    //TextView txtChild = new TextView(ln.Context);
            //    //ImageView img = new ImageView(ln.Context);

            //    //ln.Orientation = Orientation.Horizontal;
            //    //img.SetImageResource(Resource.Drawable.arrow);
            //    ////img.la
            //    //txtChild.Text = person.ParentMenu.Data;
            //    //txtChild.SetTextSize(Android.Util.ComplexUnitType.Dip, 9);
            //    //txtChild.SetPadding(4, 4, 4, 4);
                
            //    //ln.AddView(img);
            //    //ln.AddView(txtChild);
            //    //lnParent.AddView(ln);
            //    //lnParent.AddView(View.Inflate(this , txtChild.Id , null));

            //}
              //txtParentPath.Text = person.ParentMent;


                txtName.Text = person.Name;

               

                string DTelCopy = person.DirectTel;
                string ETelCopy = person.ExtensionTel;




                if (person.Email == null) txtEmail.Text = "Not Available";
                else txtEmail.Text = person.Email;

                if (person.Post == null) txtPost.Text = "Not Available";
                else txtPost.Text = person.Post;


                if (person.DirectTel == null)
                {


                    txtDTel.Text = "Not Available";
                    isNullDirect = true;
                }
                else
                {
                    isNullDirect = false;
                    if (DTelCopy.Contains("-"))
                    {

                        txtDTel.Text = DTelCopy.Replace("-", " | ");
                        isOneDirect = false;


                    }
                    else
                    {
                        txtDTel.Text = person.DirectTel;
                        isOneDirect = true;
                    }

                } //txtDTel.Text = person.DirectTel;

                if (person.ExtensionTel == null)
                {


                    txtETel.Text = "Not Available";
                    isNullInternal = true;



                }
                else
                {
                    isNullInternal = false;

                    if (ETelCopy.Contains("-"))
                    {

                        txtETel.Text = ETelCopy.Replace("-", " | ");
                        isOneInternal = false;

                    }
                    else
                    {
                        txtETel.Text = "(3550)" + person.ExtensionTel;
                        isOneInternal = true;
                    }

                } //txtETel.Text = person.ExtensionTel;







                fabPlus.Click += FabPlus_Click;

                fabDPhone.Click += FabDPhone_Click;

                fabInPhone.Click += FabInPhone_Click;

                vFabDial.Click += VFabDial_Click;

           
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
        private void VFabDial_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
        }

        private Intent intent;

        private void FabInPhone_Click(object sender, EventArgs e)
        {
            
            if (isNullInternal == true)
            {

                Toast.MakeText(this, "Not Available", ToastLength.Short).Show();

            }
            else
            {
                if (isOneInternal)
                {
                    CloseFabMenu();
                    intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:0113550" + person.ExtensionTel));
                    StartActivity(intent);


                }
                else
                {
                    CloseFabMenu();

                    var bundle = new Bundle();


                    bundle.PutString("Numbers", person.ExtensionTel);

                    FragmentTransaction transaction = FragmentManager.BeginTransaction();

                    //filterDialog.DialogClosed += FilterDialog_DialogClosed;

                    CallDialog callDialog = new CallDialog();
                    callDialog.DialogClosed += CallDialog_DialogClosed;


                    callDialog.Arguments = bundle;

                    callDialog.Show(transaction, "Call");



                }


            }



        }

        private void CallDialog_DialogClosed(object sender, DialogEventArgs e)
        {
            var clipboard = (ClipboardManager)GetSystemService(ClipboardService);
            var clip = ClipData.NewPlainText("Copy", e.ReturnValue);

            clipboard.PrimaryClip = clip;
            Toast.MakeText(this, "Phone Numbers Copied", ToastLength.Short).Show();
        }

        private void FabDPhone_Click(object sender, EventArgs e)
        {




            if (isNullDirect == true)
            {

                Toast.MakeText(this, "Not Available", ToastLength.Short).Show();

            }
            else
            {
                if (isOneDirect)
                {
                    CloseFabMenu();
                    intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:011" + person.DirectTel));
                    StartActivity(intent);


                }
                else
                {
                    CloseFabMenu();
                    //Toast.MakeText(this, "DPhone", ToastLength.Short).Show();

                    var bundle = new Bundle();


                    bundle.PutString("Numbers", person.DirectTel);

                    FragmentTransaction transaction = FragmentManager.BeginTransaction();


                    CallDialog callDialog = new CallDialog();
                    callDialog.DialogClosed += CallDialog_DialogClosed1;

                    callDialog.Arguments = bundle;

                    callDialog.Show(transaction, "Call");



                }


            }









            //CloseFabMenu();
            ////Toast.MakeText(this, "DPhone", ToastLength.Short).Show();

            //var bundle = new Bundle();


            //bundle.PutString("Direct", person.DirectTel);

            //FragmentTransaction transaction = FragmentManager.BeginTransaction();


            //DirectDialog directDialog = new DirectDialog();


            //directDialog.Arguments = bundle;

            //directDialog.Show(transaction, "DirectPhone");
        }

        private void CallDialog_DialogClosed1(object sender, DialogEventArgs e)
        {
            var clipboard = (ClipboardManager)GetSystemService(ClipboardService);
            var clip = ClipData.NewPlainText("Copy", e.ReturnValue);

            clipboard.PrimaryClip = clip;
            Toast.MakeText(this, "Phone Number Copied", ToastLength.Short).Show();
        }

        private void FabPlus_Click(object sender, EventArgs e)
        {
            if (!IsFabOpen)
            {
                ShowFabMenu();

            }
            else
            {
                CloseFabMenu();
            }


        }

        private void ShowFabMenu()
        {
            IsFabOpen = true;
            fabDPhone.Visibility = ViewStates.Visible;
            fabInPhone.Visibility = ViewStates.Visible;
            vFabDial.Visibility = ViewStates.Visible;

            fabPlus.Animate().Rotation(180f);

            fabPlus.SetImageResource(Resource.Drawable.close);
            vFabDial.Animate().Alpha(1f);
            fabDPhone.Animate().TranslationY(-Resources.GetDimension(Resource.Dimension.standard_100))
                .Rotation(0f);
            fabInPhone.Animate().TranslationY(-Resources.GetDimension(Resource.Dimension.standard_55))
              .Rotation(0f);
        }
        private void CloseFabMenu()
        {
            IsFabOpen = false;
            fabPlus.Animate().Rotation(0f);
            fabPlus.SetImageResource(Resource.Drawable.dialpad);
            vFabDial.Animate().Alpha(0f);
            fabDPhone.Animate().TranslationY(0f)
                .Rotation(90f);
            fabInPhone.Animate().TranslationY(0f)
              .Rotation(90f).SetListener(new FabAnimatorListener(vFabDial , fabInPhone , fabDPhone));
        }
        private class FabAnimatorListener : Java.Lang.Object, Animator.IAnimatorListener
        {
            View[] viewsToHide;

            public FabAnimatorListener(params View[] viewsToHide)
            {

                this.viewsToHide = viewsToHide;

            }
            public void OnAnimationCancel(Animator animation)
            {
                
            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!IsFabOpen)
                {
                    foreach (var item in viewsToHide)
                    {

                        item.Visibility = ViewStates.Gone;

                    }

                }
                
            }

            public void OnAnimationRepeat(Animator animation)
            {
                
            }

            public void OnAnimationStart(Animator animation)
            {
                
            }
        }


    }

    //public class TelAdapter : BaseAdapter<string>
    //{
    //    List<string> items;
    //    Activity context;
    //    public ColorAdapter(Activity context, List<string> items)
    //        : base()
    //    {
    //        this.context = context;
    //        this.items = items;
    //    }
    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }
    //    public override ColorItem this[int position]
    //    {
    //        get { return items[position]; }
    //    }
    //    public override int Count
    //    {
    //        get { return items.Count; }
    //    }
    //    public override View GetView(int position, View convertView, ViewGroup parent)
    //    {
    //        var item = items[position];

    //        View view = convertView;
    //        if (view == null) // no view to re-use, create new
    //            view = context.LayoutInflater.Inflate(Resource.Layout.ListItem, null);
    //        view.FindViewById<TextView>(Resource.Id.textView1).Text = item.ColorName;
    //        view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
    //        view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);

    //        return view;
    //    }
    //}
}