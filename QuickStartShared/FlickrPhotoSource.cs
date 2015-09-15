using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;

namespace QuickStart
{
	public class FlickrPhotoProvider : IPhotoProvider
	{
		public FlickrPhotoProvider ()
		{
		}

		#region IPhotoSource implementation

		public IList<Photo> GetInteresting ()
		{
			var req = (HttpWebRequest) WebRequest.Create(new Uri("https://api.flickr.com/services/feeds/photos_public.gne?format=json&sort=interestingness-desc&is-commons=true&l=4"));
			req.ContentType = "application/json";
			req.Method = "GET";
			using (var resp = req.GetResponse() as HttpWebResponse){
				if (resp.StatusCode != HttpStatusCode.OK) {
					System.Diagnostics.Debug.WriteLine ("Data error: " + resp.StatusCode.ToString());
				}
				using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
				{
					var content = reader.ReadToEnd();
					if(string.IsNullOrWhiteSpace(content)) {
						Console.Out.WriteLine("Response contained empty body...");
					}
					else {
						var photoFeed = ParseFlickrJson (content);
						req = null;
						return ParseFlickrFeed (photoFeed);
						}

				}
			}
			return null;
			//
		}

		private FlickrFeed ParseFlickrJson(string content){
			var jsonContent = content.Remove(content.Length-1,1).Remove (0, "jsonFlickrFeed(".Length).Replace(@"\'",@"'");
			Console.Out.WriteLine (jsonContent);
			var jsonSerializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer (typeof(FlickrFeed));
			return jsonSerializer.ReadObject (new MemoryStream( Encoding.UTF8.GetBytes( jsonContent ) )) as FlickrFeed;
		}

		private IList<Photo> ParseFlickrFeed(FlickrFeed feed){
			var photoList = new List<Photo> ();
			foreach (var item in feed.items) {
				photoList.Add (new Photo (){PhotoID = item.link, Title = item.title, Tags = new List<string>(item.tags.Split(' ')),  PhotoUrl = item.media.m });
			}
			return photoList;
		}

		public System.Collections.Generic.IList<Photo> GetNearPosition (decimal lat, decimal lon)
		{
			throw new NotImplementedException ();
		}

		#endregion

		private class FlickrPhoto{
			public string link {
				get;
				set;
			}
			public string title {
				get;
				set;
			}

			public string tags {
				get;
				set;
			}
			public Media media {
				get;
				set;
			}

		}

		private class Media{
			public string m {
				get;
				set;
			}
		}

		private class FlickrFeed{
			public FlickrPhoto[] items {
				get;
				set;
			}
		}
	}
		
}

