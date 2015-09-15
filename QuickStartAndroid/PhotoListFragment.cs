
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
using System.Collections.ObjectModel;

namespace QuickStart
{
	public class PhotoListFragment : BaseFragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			if (Arguments != null) {
				var ViewType = Arguments.GetString ("CurrentAppView");

				CurrentAppView = ViewType;
			}
			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.PhotoList, container, false);

			//wire up view and adapter
			var coreApp = CoreApp.SharedApp;
			var appState = coreApp.State;

			var photoList = view.FindViewById<ListView> (Resource.Id.PhotoList);

			var activity = (BaseActivity)this.Activity;


			ObservableCollection<Photo> photoSource = null;
			var thisView = (AppView)Enum.Parse (typeof(AppView), CurrentAppView);
			switch(thisView){
			case AppView.ListInteresting:
				photoSource = appState.CurrentPhotos;
				coreApp.LoadInterestingPhotos ();
				break;
			case AppView.Favorites:
				photoSource = appState.Favorites;
				break;
			}

			var photoAdapter = new ObservablePhotoCollectionAdapter (Activity, Android.Resource.Layout.SimpleListItem1, photoSource, thisView);
			photoList.Adapter = photoAdapter;


			return view;

		}


	}

}

