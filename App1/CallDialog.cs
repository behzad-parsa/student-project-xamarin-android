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
    
    public class CallDialog : DialogFragment 
    {

        View v;
        private Button btnCall;
        private Button btnCopy;
        //private RadioButton rdbJobTitle;
        //private RadioButton rdbName;
        private RadioGroup rdbG;
        //public event EventHandler<DialogEventArgs> DialogClosed;
        List<RadioButton> rdbList;
        //public string activityType;
        //ClipboardManager cp;
        //ClipData cp;
        //LinearLayout ln;
        public event EventHandler<DialogEventArgs> DialogClosed;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            

            
            base.OnCreateView(inflater, container, savedInstanceState);

            

            var view = inflater.Inflate(Resource.Layout.CallDialog, container, false);

            //btnOk = view.FindViewById<Button>(Resource.Id.btnOk);
            //rdbJobTitle = view.FindViewById<RadioButton>(Resource.Id.rdbJobTitle);
            //rdbName = view.FindViewById<RadioButton>(Resource.Id.rdbName);

            //rdbName.Checked = true;
             //ln = view.FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            btnCall = view.FindViewById<Button>(Resource.Id.btnCall);
            //btnOk.Click += BtnOk_Click;
           // v = view.FindViewById<View>(Resource.Id.)
            rdbG = view.FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            //rdbG.Orientation = Orientation.Vertical;
            btnCopy = view.FindViewById<Button>(Resource.Id.btnCopy);
            
            string numbers = Arguments.GetString("Numbers");
            rdbList = new List<RadioButton>();

            string[] numbersDirect = numbers.Split('-');


            //LinearLayout a = new LinearLayout(view.Context);
            for (int i = 0; i < numbersDirect.Length ; i++)
            {



                RadioButton rdb = new RadioButton(view.Context);
                //var b = view.FindViewById<RadioButton>(rdb.Id);
                rdb.SetPadding(10 , 0, 10, 10);
                //rdb.padding
                rdb.Text = numbersDirect[i];

                rdbList.Add(rdb);
                rdbG.AddView(rdb);
                //ln.AddView(rdbG);



            }
            //try
            //{
            //    //a.Orientation = Orientation.Horizontal
            //   // a.AddView(rdbG);
            //}
            //catch (Exception e)
            //{

            //    var h = e.Message;
            //}






            //view.AddView(ln);

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
            //ClipboardManager clipboard = (ClipboardManager)GetSystemService(ClipboardService);



            btnCall.Click += BtnCall_Click;
            btnCopy.Click += BtnCopy_Click;

            
            return view;




        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {

            //var clip = ClipData.NewPlainText("your_text_to_be_copied");

            //clipboard.PrimaryClip = clip;
            foreach (var item in rdbList)
            {
                if (item.Checked)
                {
                    DialogClosed(this, new DialogEventArgs { ReturnValue = item.Text});
                    this.Dismiss();
                    break;
                }
            }
            
        }

        private void BtnCall_Click(object sender, EventArgs e)
        {
            Intent intent;
            foreach (var item in rdbList)
            {
                if (item.Checked)
                {
                    //Direct
                    if (item.Text.Length > 5)
                    {

                        intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:011" + item.Text));
                        StartActivity(intent);
                        this.Dismiss();
                        break;  


                    }
                    else
                    {

                        intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:0113550" + item.Text));
                        StartActivity(intent);
                        this.Dismiss();
                        break;


                    }
                  
                    


                }


            }

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


     