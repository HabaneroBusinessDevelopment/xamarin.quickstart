﻿
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

namespace QuickStart
{
	public abstract class BaseFragment : Fragment
	{
		public string CurrentAppView {
			get;
			set;
		}
	}
}

