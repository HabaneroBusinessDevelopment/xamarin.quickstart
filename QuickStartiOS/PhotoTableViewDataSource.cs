using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Collections.ObjectModel;

namespace QuickStart
{

	public class PhotoTableViewDataSource : UITableViewDataSource{
		private ObservableCollection<Photo> backingList;
		string _cellID;
		public	PhotoTableViewDataSource(ObservableCollection<Photo> list){
			backingList = list;
			_cellID = "_photocelll";
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

			s = row + ":" + cell.Subviews.Count();


			if (row.Equals(5))
			{
				UILabel l = new UILabel(new RectangleF(10f, 10f, 200f, 20f));
				l.Text = backingList[n].Title;
				l.BackgroundColor = UIColor.Red;
				//UIView v = new UIView(new RectangleF(10f, 10f, 20f, 20f));
				//v.BackgroundColor = UIColor.Green;
				cell.Add(l);
			}

			if (row < 20)
			{

				cell.TextLabel.Text = backingList[n].Title;
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
