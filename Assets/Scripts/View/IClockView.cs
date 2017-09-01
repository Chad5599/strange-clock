using System;

using strange.extensions.signal.impl;

namespace Clock
{
	public interface IClockView
	{
		Signal GetTimeButtonClickedSignal 
		{
			get;
		}

		void Init ();

		void UpdateTime (DateTime dateTime);
	
	}
}
