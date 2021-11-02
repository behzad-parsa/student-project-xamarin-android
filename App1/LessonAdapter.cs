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
    public class LessonAdapter : BaseAdapter<Lesson>
    {
        List<Lesson> items;
        Activity context;
        public LessonAdapter(Activity context, List<Lesson> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Lesson this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public Lesson GetItemAtPosition(int position)
        {
            return items[position];
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            List<Lesson> _item = new List<Lesson>();
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.AverageListItem, null);
            
            view.FindViewById<TextView>(Resource.Id.txtLesson).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.txtUnit).Text = item.Unit.ToString();
            view.FindViewById<TextView>(Resource.Id.txtGrade).Text = item.Grade.ToString();
            var btnDelete = view.FindViewById<ImageButton>(Resource.Id.imgDelete);
            btnDelete.Click += (sender, e) =>
              {
                  items.Remove(items.Find(r => r == item));

                  NotifyDataSetChanged();
                  /////base.no




              };

            // view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
            // view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);

            return view;
        }

 
    }
    //public class LessonAdapter : BaseAdapter<Lesson>
    //{


    //}
    //public class HomeScreenAdapter : BaseAdapter<TableItem>
    //{
    //    List<TableItem> items;
    //    Activity context;
    //    public HomeScreenAdapter(Activity context, List<TableItem> items)
    //        : base()
    //    {
    //        this.context = context;
    //        this.items = items;
    //    }
    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }
    //    public override TableItem this[int position]
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
    //            view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
    //        view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
    //        view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
    //        view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
    //        return view;
    //    }
    //}
}