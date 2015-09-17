using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;

namespace QuickStart
{
	partial class StartNavController : UITableViewController
	{
		public StartNavController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			
			base.ViewWillAppear (animated);

			this.TableView.DataSource = new NameTableViewDataSource (MainMenu.MenuOptions.Select(m=>m.Name).ToArray());
			this.TableView.Delegate = new MainNavDelegate (CoreApp.SharedApp);

		}
	
		private class MainNavDelegate : UITableViewDelegate{
			private CoreApp _context;

			public MainNavDelegate(CoreApp context){
				_context = context;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var row = indexPath.Row;


				int n = (int) indexPath.IndexAtPosition(indexPath.Length - 1);
				_context.PresentationManager.ShowView (MainMenu.MenuOptions [n].View);
			}
}
	}
		
}
