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
    public class ProductAdapter : RecyclerView.Adapter , IFilterable
    {
        private Activity context;
        private List<Product> mProduct;

        List<Product> _originalData;


        public Filter Filter { get; set; }
        public event EventHandler<int> ItemClick;
        public ProductAdapter(Activity context, List<Product> product)
        {
            this.context = context;
            this.mProduct = product;
            Filter = new ProductFilter(this);
        }


        public class ProductAdapterViewHolder : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            //public ImageView mIcon { get; set; }
            public TextView mTitle { get; set; }
            public TextView mDate{ get; set; }
            public TextView mTime { get; set; }
            public TextView mPrice { get; set; }



            public ProductAdapterViewHolder(View view, Action<int> listener) : base(view)
            {
                mMainView = view;

                view.Click += (sender, e) => listener(base.Position);
            }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.AdListItem, parent, false);

            TextView txtTitle = row.FindViewById<TextView>(Resource.Id.txtProductName);
            TextView txtDate = row.FindViewById<TextView>(Resource.Id.txtADDate);
            TextView txtTime = row.FindViewById<TextView>(Resource.Id.txtADTime);
            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.txtPrice);
            //ImageView imgIcon = row.FindViewById<ImageView>(Resource.Id.imgIcon);

            ProductAdapterViewHolder productHolder = new ProductAdapterViewHolder(row, OnClick) { mTitle = txtTitle , mDate=txtDate , mTime = txtTime , mPrice = txtPrice} ;

            return productHolder;


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
            ProductAdapterViewHolder myHolder = holder as ProductAdapterViewHolder;
            myHolder.mTitle.Text = mProduct[position].Title;
            //myHolder.mIcon.SetImageResource(mCategory[position].IconID);
            myHolder.mPrice.Text =string.Format("{0:n0}", double.Parse(mProduct[position].Price)); 
            myHolder.mTime.Text = mProduct[position].Date.ToString("HH:mm:ss");
            myHolder.mDate.Text = mProduct[position].Date.ToString("yyyy-MM-dd"); 
        }
    
        public override int ItemCount
        {
            get { return mProduct.Count; }
        }

        public Product GetItemAtPosition(int position)
        {
            return mProduct[position];
        }



        private class ProductFilter : Filter
        {
            private readonly ProductAdapter _adapter;
            // private readonly string _activityType;
            public ProductFilter(ProductAdapter adapter)
            {
                _adapter = adapter;
                //_activityType = _adapter.ActivityType;
            }

            protected override FilterResults PerformFiltering(ICharSequence constraint)
            {
                var returnObj = new FilterResults();
                var results = new List<Product>();
                if (_adapter._originalData == null)
                    _adapter._originalData = _adapter.mProduct;


                if (constraint == null) return returnObj;

                if (_adapter._originalData != null && _adapter._originalData.Any())
                {
                    // Compare constraint to all names lowercased. 
                    // It they are contained they are added to results.
                    results.AddRange(
                        _adapter._originalData.Where(
                            items => items.Title.ToLower().Contains(constraint.ToString())));


                    //if (_adapter.ActivityType == "Name")
                    //{
                    //    results.AddRange(
                    //           _adapter._originalData.Where(
                    //           items => items.Title.ToLower().Contains(constraint.ToString())));


                    //}
                    //else
                    //{

                    //    results.AddRange(
                    //              _adapter._originalData.Where(
                    //                  items => items.Title.ToLower().Contains(constraint.ToString())));


                    //}




                }
                returnObj.Values = FromArray(results.Select(r => r.ToJavaObject()).ToArray());
                returnObj.Count = results.Count;

                constraint.Dispose();


                return returnObj;
            }

            protected override void PublishResults(ICharSequence constraint, FilterResults results)
            {
                using (var values = results.Values)
                    _adapter.mProduct = values.ToArray<Object>()
                        .Select(r => r.ToNetObject<Product>()).ToList();

                _adapter.NotifyDataSetChanged();

                // Don't do this and see GREF counts rising
                constraint.Dispose();
                results.Dispose();
            }



        }







    }





















   



}