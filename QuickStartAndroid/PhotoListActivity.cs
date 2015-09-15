
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

namespace QuickStart
{
	[Activity (Label = "PhotoListActivity")]			
	public class PhotoListActivity : BaseActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			if (Resources.Configuration.Orientation != Android.Content.Res.Orientation.Portrait){
				Finish ();
				return;
			}

			var coreApp = CoreApp.SharedApp;

			if (bundle == null) {
				PhotoListFragment photolist = new PhotoListFragment ();
				photolist.Arguments = Intent.Extras;
				FragmentManager.BeginTransaction ().Add (Android.Resource.Id.Content, photolist).Commit ();
			}
			// Create your application here
		}
	}
}

