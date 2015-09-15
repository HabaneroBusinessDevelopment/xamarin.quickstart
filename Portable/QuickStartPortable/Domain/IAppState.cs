using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace QuickStart
{

	public interface IAppState{

		ObservableCollection<Photo> Favorites { get;}
		ObservableCollection<Photo> CurrentPhotos{ get;}

		void AddFavorite(Photo photo);
		void RemoveFavorite(Photo photo);
	}

}
	