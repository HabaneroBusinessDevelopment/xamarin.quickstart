
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
using System.Collections.ObjectModel;

namespace QuickStart
{

	public class ObservablePhotoCollectionAdapter : ArrayAdapter<Photo> {

		private readonly Activity parentActivity;
		private readonly AppView appView;

		public ObservablePhotoCollectionAdapter(Activity context, int resource, ObservableCollection<Photo> collection, AppView theView):base(context, resource, collection){
			parentActivity = context;
			appView = theView;
			collection.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				parentActivity.RunOnUiThread (() => {
					if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
						this.Remove ((Photo)e.OldItems [0]);
					}
					if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
						this.AddAll (e.NewItems);
					}
				});
			};

		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? parentActivity.LayoutInflater.Inflate (
				Resource.Layout.PhotoListItem, parent, false);

			var photo = this.GetItem (position) as Photo;

			var photoImage = view.FindViewById<ImageButton> (Resource.Id.ListPhotoImage);
			var photoTitle = view.FindViewById<TextView> (Resource.Id.ListPhotoTitle);

			photoImage.Click += (object sender, EventArgs e) => {
				var state = CoreApp.SharedApp.State;
				if(appView == AppView.Favorites)
					state.RemoveFavorite(photo);
				else
					state.AddFavorite (photo);
			};

			if (photo != null) {
				photoTitle.Text = photo.Title;
				if (photo.PhotoBytes == null) {
					photo.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
						if (e.PropertyName == "PhotoBytes") {
							LoadImage (photoImage, photo.PhotoBytes);
						}
					};
					PhotoLoader.LoadPhotoUrl (photo);
				} else
					LoadImage (photoImage, photo.PhotoBytes);

			}
			return view;
		}

		private void LoadImage(ImageView view, byte[] bytes){
			view.SetImageBitmap ( Android.Graphics.BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length));
			view.Invalidate ();
		}
	}
}
