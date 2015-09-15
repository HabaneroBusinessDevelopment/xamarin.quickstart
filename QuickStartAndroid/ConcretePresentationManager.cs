using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace QuickStart
{

	internal class ConcretePresentationManager : PresentationManager{

		public BaseActivity CurrentActivity {
			get;
			set;
		}

		internal ConcretePresentationManager(Activity act){
			CurrentActivity = (BaseActivity)act;
		}

		#region implemented abstract members of PresentationManager

		protected override void DoShowView (AppView theView)
		{
			
			Intent intent = null;
			BaseFragment details = null;

			switch (theView) {
			case AppView.ListInteresting:
			case AppView.Favorites:
				if (CurrentActivity.Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape) {
					details = CurrentActivity.FragmentManager.FindFragmentById (Resource.Id.details) as PhotoListFragment;
					if (details != null && details.CurrentAppView == theView.ToString ())
						return;
					details = new PhotoListFragment ();
				} else
					intent = new Intent (CurrentActivity, typeof(PhotoListActivity));
				break;
			case AppView.About:
				intent = new Intent (CurrentActivity, typeof(AboutActivity));
				break;
			default:
				return;
			}
				

			if (intent !=null) {
				intent.PutExtra ("CurrentAppView", theView.ToString ());
				CurrentActivity.StartActivity (intent);
			} else {
				if (details != null) {
					details.CurrentAppView = theView.ToString ();

					var ft = CurrentActivity.FragmentManager.BeginTransaction ();
					ft.Replace (Resource.Id.details, details);
					ft.SetTransition (FragmentTransit.FragmentFade);
					ft.Commit ();
				}
			}
		}


		public override void GoBack ()
		{
			throw new NotImplementedException ();
		}
		
		#endregion

}
}
