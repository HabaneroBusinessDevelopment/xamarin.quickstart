using System;

namespace QuickStart
{
	public class AppStateStorage : IStateStorage
	{
		public AppStateStorage ()
		{
			
		}

		public bool Store(IAppState state){
			return false;
		}

		public bool Load(IAppState state){
			return false;
		}
	}
}

