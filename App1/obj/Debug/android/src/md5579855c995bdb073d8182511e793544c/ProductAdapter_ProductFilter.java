package md5579855c995bdb073d8182511e793544c;


public class ProductAdapter_ProductFilter
	extends android.widget.Filter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_performFiltering:(Ljava/lang/CharSequence;)Landroid/widget/Filter$FilterResults;:GetPerformFiltering_Ljava_lang_CharSequence_Handler\n" +
			"n_publishResults:(Ljava/lang/CharSequence;Landroid/widget/Filter$FilterResults;)V:GetPublishResults_Ljava_lang_CharSequence_Landroid_widget_Filter_FilterResults_Handler\n" +
			"";
		mono.android.Runtime.register ("App1.ProductAdapter+ProductFilter, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProductAdapter_ProductFilter.class, __md_methods);
	}


	public ProductAdapter_ProductFilter ()
	{
		super ();
		if (getClass () == ProductAdapter_ProductFilter.class)
			mono.android.TypeManager.Activate ("App1.ProductAdapter+ProductFilter, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public ProductAdapter_ProductFilter (md5579855c995bdb073d8182511e793544c.ProductAdapter p0)
	{
		super ();
		if (getClass () == ProductAdapter_ProductFilter.class)
			mono.android.TypeManager.Activate ("App1.ProductAdapter+ProductFilter, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "App1.ProductAdapter, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public android.widget.Filter.FilterResults performFiltering (java.lang.CharSequence p0)
	{
		return n_performFiltering (p0);
	}

	private native android.widget.Filter.FilterResults n_performFiltering (java.lang.CharSequence p0);


	public void publishResults (java.lang.CharSequence p0, android.widget.Filter.FilterResults p1)
	{
		n_publishResults (p0, p1);
	}

	private native void n_publishResults (java.lang.CharSequence p0, android.widget.Filter.FilterResults p1);

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
