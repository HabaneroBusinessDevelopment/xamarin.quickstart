using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace QuickStart
{
		
	public static class PhotoLoader {

		private static Semaphore locker = new Semaphore(2,2);

		public static void LoadPhotoUrl(Photo photo){
			if (photo.PhotoBytes == null) {
				var url = photo.PhotoUrl;

				var request = HttpWebRequest.Create (url);
				var ms = new MemoryStream ();
				locker.WaitOne ();
				using (var stream = ((HttpWebResponse)request.GetResponse ()).GetResponseStream ()) {

					var bytes = new byte[256];

					int read;
					while ((read = stream.Read (bytes, 0, bytes.Length)) > 0) {
						ms.Write (bytes, 0, read);
					}
				}
				locker.Release ();
				photo.PhotoBytes = ms.ToArray ();
			}
		}
			
	}
}
