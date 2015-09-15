using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace QuickStart
{

	public class BaseActivity : Activity{


		//internal CoreApp coreApp { get; set; }
		protected override void OnResume ()
		{
			base.OnResume ();

			CoreApp.SharedApp.Start ();
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			CoreApp.SharedApp.Stop ();
		}
	}

}
