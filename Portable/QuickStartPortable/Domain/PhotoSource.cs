using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QuickStart
{

	public struct PhotoSource{
		public enum SourceType{
			Interesting,
			NearPosition,
			ForTags
		}

		public SourceType Source {
			get;
			set;
		}

		public string[] Tags {
			get;
			set;
		}

		public LatLonCoords LatLon {
			get;
			set;
		}

		public struct LatLonCoords{
			public decimal Lat {
				get;
				set;
			}

			public decimal Lon {
				get;
				set;
			}
		}
	}
}
	