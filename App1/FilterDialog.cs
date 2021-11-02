using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace App1
{
    public class FilterDialog : DialogFragment 
    {
        //Contact person;
        // TextView txtName;
        //TextView txtEmail;
        //TextView txtPost;
        //TextView tel1;
        //TextView tel2;
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    Window.RequestFeature(WindowFeatures.NoTitle);
        //    // Create your application here
        //    SetContentView(Resource.Layout.Detail);

        //    person = JsonConvert.DeserializeObject<Contact>(Intent.GetStringExtra("person"));

        //    txtName = FindViewById<TextView>(Resource.Id.txtName);
        //    txtEmail = FindViewById<TextView>(Resource.Id.txtEmail);
        //    txtPost = FindViewById<TextView>(Resource.Id.txtPost);

        //    txtName.Text = person.Name;
        //    txtEmail.Text = person.Email;
        //    txtPost.Text = person.Post;



        private Button btnOk;
        private RadioButton rdbJobTitle;
        private RadioButton rdbName;
        public event EventHandler<DialogEventArgs> DialogClosed;

        public string activityType;



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {


            
            base.OnCreateView(inflater, container, savedInstanceState);

            

            var view = inflater.Inflate(Resource.Layout.FilterDialog, container, false);

            btnOk = view.FindViewById<Button>(Resource.Id.btnOk);
            rdbJobTitle = view.FindViewById<RadioButton>(Resource.Id.rdbJobTitle);
            rdbName = view.FindViewById<RadioButton>(Resource.Id.rdbName);

            rdbName.Checked = true;

            btnOk.Click += BtnOk_Click;



            //txtName = view.FindViewById<TextView>(Resource.Id.txtName);
            //txtEmail = view.FindViewById<TextView>(Resource.Id.txtEmail);
            //txtPost = view.FindViewById<TextView>(Resource.Id.txtPost);
            //tel1 = view.FindViewById<TextView>(Resource.Id.txtTel1);
            //tel2 = view.FindViewById<TextView>(Resource.Id.txtTel2);

            //person = JsonConvert.DeserializeObject<Contact>(this.Activity.Intent.GetStringExtra("person"));

            
             //var person = JsonConvert.DeserializeObject<Contact>(Arguments.GetString("person"));
            //var h3 = h2 as Contact;
            //txtName.Text = person.Name;
            //txtEmail.Text = person.Email;
            // txtPost.Text = person.Post;
            //tel1.Text = person.DirectTel;
            //tel2.Text = person.ExtensionTel;


            //txtName = view.FindViewById<TextView>(Resource.Id.txtName);
            

            return view;




        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //Intent intent = new Intent(Application.Context, typeof(Detail));
            //intent.PutExtra("person", JsonConvert.SerializeObject(person));
            //StartActivity(intent);
            //OverridePendingTransition(Resource.Animation.slide_right, Resource.Animation.fade_out);

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


           
            if (rdbJobTitle.Checked)
            {

                activityType = "JobTitle";

            }
            else
            {

                activityType = "Name";

            }
            DialogClosed(this, new DialogEventArgs { ReturnValue = activityType });

            this.Dismiss();
                        
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {

            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
            


        }

        //public override void OnDismiss(IDialogInterface dialog)
        //{
        //    base.OnDismiss(dialog);
        //    if (DialogClosed != null)
        //    {
        //        DialogClosed(this, new DialogEventArgs { ReturnValue = activityType });
        //    }

        //}



        public class DialogEventArg
        {

            public string ReturnValue { get; set; }
        }

    }

}