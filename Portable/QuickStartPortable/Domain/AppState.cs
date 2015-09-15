using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace QuickStart
{
	public class AppState : IAppState
    {
        public ObservableCollection<Photo> Favorites { get; private set; } 

		public void AddFavorite (Photo photo)
		{
			if (!Favorites.Any (p => p.PhotoID == photo.PhotoID)) {
				Favorites.Add (photo);
			}
		}

		public void RemoveFavorite (Photo photo)
		{
			if (Favorites.Any (p => p.PhotoID == photo.PhotoID)) {
				Favorites.Remove (photo);
			}
		}

		public ObservableCollection<Photo> CurrentPhotos {
			get;
			set;
		}

		private readonly IStateStorage _storage;

		public AppState(IStateStorage storage)
       {
			Favorites = new ObservableCollection<Photo> ();
			_storage = storage;
			CurrentPhotos = new ObservableCollection<Photo> ();
       }
			
		public void ReloadState(){
			//Load from disk
			 _storage.Store(this);
		}

		public void StoreState(){
			//Store to disk
			 _storage.Store(this);
		}


    }





}
	