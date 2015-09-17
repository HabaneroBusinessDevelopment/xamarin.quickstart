using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;
using System.Drawing;

namespace QuickStart
{

	public class NameTableViewDataSource : UITableViewDataSource{
		private string[] backingList;
		string _cellID;
		public	NameTableViewDataSource(string[] list){
			backingList = list;
			_cellID = "_mainmenucelll";
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			// For more information on why this is necessary, see the Apple docs
			var row = indexPath.Row;

			UITableViewCell cell = tableView.DequeueReusableCell(_cellID);

			int n = (int) indexPath.IndexAtPosition(indexPath.Length - 1);

			if (cell == null)
			{
				// See the styles demo for different UITableViewCellAccessory
				cell = new UITableViewCell(UITableViewCellStyle.Default, _cellID);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			}

			string s = "";

			s = row + ":" + cell.Subviews.Length;

			if (row.Equals(5))
			{
				UILabel l = new UILabel(new RectangleF(10f, 10f, 200f, 20f));
				l.Text = backingList[n];
				l.BackgroundColor = UIColor.Red;
				//UIView v = new UIView(new RectangleF(10f, 10f, 20f, 20f));
				//v.BackgroundColor = UIColor.Green;
				cell.Add(l);
			}

			if (row < 20)
			{

				cell.TextLabel.Text = backingList[n];
			}

			//s = s + ":" + cell.Subviews.Count();
			//Console.WriteLine(s);

			return cell;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return backingList.Count ();
		}

	}
		
}
