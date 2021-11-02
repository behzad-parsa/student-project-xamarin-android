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
    [Activity(Label = "InternalDialog")]
    public class InternalDialog : DialogFragment
    {



        private Button btnOk;
        private RadioButton rdbJobTitle;
        private RadioButton rdbName;
        public event EventHandler<DialogEventArgs> DialogClosed;

        public string activityType;



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {



            base.OnCreateView(inflater, container, savedInstanceState);



            var view = inflater.Inflate(Resource.Layout.InternalDialog, container, false);


            //DialogFragment DF = new DialogFragment();
           
            string InternalTel= Arguments.GetString("content");



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

        

        public override void OnActivityCreated(Bundle savedInstanceState)
        {

            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;



        }






    }
    public class DialogEventArgs
    {

        public string ReturnValue { get; set; }
    }




}

