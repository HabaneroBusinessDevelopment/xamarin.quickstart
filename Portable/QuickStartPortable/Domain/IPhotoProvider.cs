using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QuickStart
{

	public interface IPhotoProvider{
		IList<Photo> GetInteresting();
		IList<Photo> GetNearPosition(decimal lat, decimal lon);
	}

	
}
	