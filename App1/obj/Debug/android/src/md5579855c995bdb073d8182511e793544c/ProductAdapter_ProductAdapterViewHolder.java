package md5579855c995bdb073d8182511e793544c;


public class ProductAdapter_ProductAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App1.ProductAdapter+ProductAdapterViewHolder, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProductAdapter_ProductAdapterViewHolder.class, __md_methods);
	}


	public ProductAdapter_ProductAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ProductAdapter_ProductAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("App1.ProductAdapter+ProductAdapterViewHolder, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
