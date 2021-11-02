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
using Android.Support.V7;

using Android.Support.V7.Widget;




namespace App1
{
    public class CategoryAdapter : RecyclerView.Adapter
    {
        private Activity context;
        private List<Category> mCategory;
        public event EventHandler<int> ItemClick;
        public CategoryAdapter(Activity context , List<Category> category) 
        {
            this.context = context;
            this.mCategory = category;
        }


        public class CategoryAdapterViewHolder : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mIcon { get; set; }
            public TextView mTitle { get; set; }

            public CategoryAdapterViewHolder(View view , Action<int> listener) : base(view)
            {
                mMainView = view;

                view.Click += (sender, e) => listener(base.Position);
            }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CategoryRecyclerRowItem, parent , false);

            TextView txtTitle = row.FindViewById<TextView>(Resource.Id.txtIconTitle);
            ImageView imgIcon = row.FindViewById<ImageView>(Resource.Id.imgIcon);

            CategoryAdapterViewHolder categoryHolder = new CategoryAdapterViewHolder(row , OnClick) { mIcon = imgIcon  , mTitle =txtTitle  };

            return categoryHolder;


        }
        private void OnClick(int position)
        {
            if (ItemClick != null)
            {
                ItemClick(this, position);
            }
        }
        //

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CategoryAdapterViewHolder myHolder = holder as CategoryAdapterViewHolder;
            myHolder.mTitle.Text = mCategory[position].Name;
            myHolder.mIcon.SetImageResource(mCategory[position].IconID);
        }

        public override int ItemCount
        {
            get { return mCategory.Count; }
        }

        public Category GetItemAtPosition(int position)
        {
            return mCategory[position];
        }





    }
}