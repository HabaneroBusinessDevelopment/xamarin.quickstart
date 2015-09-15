using System;
using System.Drawing;
using Foundation;
using UIKit;
using System.Linq;

namespace QuickStart
{

	public class ConcretePresentationManager : PresentationManager{
		protected override void DoShowView (AppView view)
		{
			
			string viewName = null;
			switch (view) {
			case AppView.ListInteresting:
			case AppView.Favorites:
				viewName = "ListPhotos";
				break;
			case AppView.About:
				viewName = "About";
				break;
			}
			var vc = ((AppDelegate)UIApplication.SharedApplication.Delegate).Window.RootViewController;
			var newView = vc.Storyboard.InstantiateViewController (viewName);
			vc.ShowDetailViewController (newView, null);
		}
			

		public override void GoBack ()
		{
			throw new NotImplementedException ();
		}

	}
	
}