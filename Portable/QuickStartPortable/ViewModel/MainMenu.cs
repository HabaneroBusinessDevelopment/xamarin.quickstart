using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickStart
{
	public enum AppView{
		ListInteresting = 0,
		ListNearby = 100,
		About = 400,
		Favorites = 500
	}
	
	public class MainMenu
	{
		
		
		public MainMenu ()
		{
		}

		static public MenuOption[] MenuOptions {
			get{ return new	[] { 
					new MenuOption (AppView.ListInteresting, "Interesting Photos"),
					//new MenuOption (AppView.ListNearby, "Nearby Photos"),

					new MenuOption (AppView.Favorites, "Favorites"),
					new MenuOption(AppView.About, "About")
				};}
		}


		public class MenuOption {

			public MenuOption(AppView view, string name){
				Name = name;
				View = view;
			}

			public AppView View {
				get;
				set;
			}


			public string Name {
				get;
				private set;
			}

}
	}
}

