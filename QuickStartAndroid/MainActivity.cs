using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace QuickStart
{
    [Activity(Label = "QuickStartAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        int count = 1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			CoreApp.SharedApp = new CoreApp (3000, new AppState (new AppStateStorage()));
			CoreApp.SharedApp.PresentationManager = new ConcretePresentationManager (this);
			CoreApp.SharedApp.PhotoProvider = new FlickrPhotoProvider ();
        }

		protected override void OnRestoreInstanceState (Bundle savedInstanceState)
		{
			base.OnRestoreInstanceState (savedInstanceState);

			//restore app state after pause/stop
		}
			
    }
		

}

