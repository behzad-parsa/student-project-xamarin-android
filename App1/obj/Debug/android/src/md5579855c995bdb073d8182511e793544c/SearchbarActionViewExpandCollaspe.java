package md5579855c995bdb073d8182511e793544c;


public class SearchbarActionViewExpandCollaspe
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.MenuItemCompat.OnActionExpandListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuItemActionCollapse:(Landroid/view/MenuItem;)Z:GetOnMenuItemActionCollapse_Landroid_view_MenuItem_Handler:Android.Support.V4.View.MenuItemCompat/IOnActionExpandListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"n_onMenuItemActionExpand:(Landroid/view/MenuItem;)Z:GetOnMenuItemActionExpand_Landroid_view_MenuItem_Handler:Android.Support.V4.View.MenuItemCompat/IOnActionExpandListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("App1.SearchbarActionViewExpandCollaspe, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SearchbarActionViewExpandCollaspe.class, __md_methods);
	}


	public SearchbarActionViewExpandCollaspe ()
	{
		super ();
		if (getClass () == SearchbarActionViewExpandCollaspe.class)
			mono.android.TypeManager.Activate ("App1.SearchbarActionViewExpandCollaspe, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public SearchbarActionViewExpandCollaspe (android.view.Menu p0)
	{
		super ();
		if (getClass () == SearchbarActionViewExpandCollaspe.class)
			mono.android.TypeManager.Activate ("App1.SearchbarActionViewExpandCollaspe, App1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.IMenu, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public boolean onMenuItemActionCollapse (android.view.MenuItem p0)
	{
		return n_onMenuItemActionCollapse (p0);
	}

	private native boolean n_onMenuItemActionCollapse (android.view.MenuItem p0);


	public boolean onMenuItemActionExpand (android.view.MenuItem p0)
	{
		return n_onMenuItemActionExpand (p0);
	}

	private native boolean n_onMenuItemActionExpand (android.view.MenuItem p0);

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
