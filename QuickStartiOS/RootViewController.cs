using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace QuickStart
{
    public partial class RootViewController : UIViewController
    {
		

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public RootViewController(IntPtr handle) : base(handle)
        {
			
        }

      

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
			//Init common stuff


            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {

            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }


		partial void UIButton28_TouchUpInside (UIButton sender)
		{
			//CoreApp.SharedApp.PresentationManager.ShowView(Shared.GameView.CreateCompany);
		}
        #endregion

      
    }
		
}