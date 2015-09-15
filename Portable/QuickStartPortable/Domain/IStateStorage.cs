using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QuickStart
{

	public interface IStateStorage{
		bool Store(IAppState state);
		bool Load(IAppState state);
	}

}
	