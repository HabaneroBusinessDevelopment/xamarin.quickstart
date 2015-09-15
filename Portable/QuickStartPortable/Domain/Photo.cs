using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace QuickStart
{
	public class Photo : INotifyPropertyChanged
    {
        public string PhotoID { get; set; }
        public string PhotoUrl { get; set; }
		public string Title {
			get;
			set;
		}
		public byte[] PhotoBytes {
			get;
			set;
		}
		public IList<string> Tags {
			get;
			set;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

    }

}
