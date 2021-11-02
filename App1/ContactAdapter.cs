using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Object = Java.Lang.Object;
using Android.Support.V7.Widget;
using System;
using Android.Content;
using Newtonsoft.Json;

namespace App1
{
    public class ContactAdapter : BaseAdapter<Contact>, IFilterable
    {

        private readonly Activity context;


        List<Contact> items;

        List<Contact> _originalData;


        public Filter Filter { get; set; }

        private readonly string ActivityType;
            
        public ContactAdapter(Activity context, List<Contact> items) : base()
        {

            //this.context = context;
            //this.items = items;

            this.items = items.OrderBy(s => s.Name).ToList();
           // this.items = items;
            this.context = context;
        

            Filter = new ContactFilter(this);


        }
        public ContactAdapter(Activity context, List<Contact> items , string type) : base()
        {

            //this.context = context;
            //this.items = items;

            this.items = items.OrderBy(s => s.Name).ToList();
            // this.items = items;
            this.context = context;


            Filter = new ContactFilter(this);
            this.ActivityType = type;

        }


        //Object obj = 

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        //public override Java.Lang.Object GetItem(int position)
        //{
        //    // object it = items as object;
        //    return (object)items.ElementAt(position);
        //}

        //public override Java.Lang.Object GetItem(int position)
        //{
        //    // object it = items as object;
        //    return items.ElementAt(position);
        //}
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Contact this[int position]
        {
            get { return items[position]; }
        }
        public Contact GetItemAtPosition(int position)
        {
            return items[position];
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            
            
            View view  = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.ListItem, null);

            if (ActivityType == "Name")
            {
                view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;

            }
            else
            {

                view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Post;

            }
            //view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;


            //view.FindViewById<ImageView>(Resource.Id.imgArrow).SetImageResource(item.imgResourceId);



            //img.SetBackgroundResource(item);
            //TextView Name = view.FindViewById<TextView>(Resource.Id.textView1);
            //Name.Text = item.Name;


            //view.Click += delegate
            //{
            //    //Toast.MakeText(context, Name.Text, ToastLength.Short).Show();
            //    //or
            //    // Toast.MakeText(mContext, mFriends[position].FirstName, ToastLength.Short).Show();
            //    //var item = lstContact[e.Position];

            //    //var item2 = lstContact[e.Parent];

            //    //Toast.MakeText(this, item.ToString(), ToastLength.Short).Show();




            //    Intent Intent = new Intent(Application.Context, typeof(Detail));
            //    Intent.PutExtra("person", JsonConvert.SerializeObject(item));



            //    // StartActivity(Intent);
            //};


            return view;
        }

        
       
        public override void NotifyDataSetChanged()
        {
            // If you are using cool stuff like sections
            // remember to update the indices here!
            base.NotifyDataSetChanged();
        }

        private class ContactFilter : Filter
        {
            private readonly ContactAdapter _adapter;
           // private readonly string _activityType;
            public ContactFilter(ContactAdapter adapter)
            {
                _adapter = adapter;
                //_activityType = _adapter.ActivityType;
            }

            protected override FilterResults PerformFiltering(ICharSequence constraint)
            {
                var returnObj = new FilterResults();
                var results = new List<Contact>();
                if (_adapter._originalData == null)
                    _adapter._originalData = _adapter.items;
                

                if (constraint == null) return returnObj;

                if (_adapter._originalData != null && _adapter._originalData.Any())
                {
                    // Compare constraint to all names lowercased. 
                    // It they are contained they are added to results.
                    //results.AddRange(
                    //    _adapter._originalData.Where(
                    //        items => items.Name.ToLower().Contains(constraint.ToString())));

                    if (_adapter.ActivityType == "Name")
                    {
                        results.AddRange(
                               _adapter._originalData.Where(
                               items => items.Name.ToLower().Contains(constraint.ToString())));
 

                    }
                    else
                    {

                        results.AddRange(
                                  _adapter._originalData.Where(
                                      items => items.Post.ToLower().Contains(constraint.ToString())));
  

                    }




                }
                returnObj.Values = FromArray(results.Select(r => r.ToJavaObject()).ToArray());
                returnObj.Count = results.Count;

                constraint.Dispose();


                return returnObj;
            }

            protected override void PublishResults(ICharSequence constraint, FilterResults results)
            {
                using (var values = results.Values)
                    _adapter.items = values.ToArray<Object>()
                        .Select(r => r.ToNetObject<Contact>()).ToList();

                _adapter.NotifyDataSetChanged();

                // Don't do this and see GREF counts rising
                constraint.Dispose();
                results.Dispose();
            }



        }







    }



    public class JavaHolder : Java.Lang.Object
    {
        public readonly object Instance;

        public JavaHolder(object instance)
        {
            Instance = instance;
        }
    }
}