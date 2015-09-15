
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace QuickStart
{
	public class StartNavFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.StartNav, container, false);

			var list = view.FindViewById<ListView> (Resource.Id.NavList);
			list.Adapter = new ArrayAdapter (Activity.ApplicationContext, Android.Resource.Layout.SimpleListItem1, MainMenu.MenuOptions.Select(o=>o.Name).ToList());
			list.ItemClick += List_Click;
			return view;

			//return base.OnCreateView (inflater, container, savedInstanceState);
		}

		void List_Click (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			var view = MainMenu.MenuOptions [e.Position].View;

			var act = (BaseActivity) Activity;
			CoreApp.SharedApp.PresentationManager.ShowView(view);	
		}
	}
}

