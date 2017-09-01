using System;

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Clock
{
	public class analogueClock3DView : View , IClockView
	{
		public Button getTimeButton;
		public Transform hours, minutes, seconds;
		public Signal getTimeButtonClickedSignal = new Signal();

		private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;
		private bool clockStart = false;

		DateTime time = DateTime.MinValue;

		void FixedUpdate ()
		{
			if (clockStart) 
			{
				float analogueHours = ((time.Hour - 12f) + (time.Minute / 60f) + (time.Second / 3600f));
				float analogueMinutes = (time.Minute + (time.Second / 60f));
				float analogueSeconds = time.Second;

				time = time.AddSeconds (.02);
				hours.localRotation = Quaternion.Euler (0f, 0f, analogueHours * -hoursToDegrees);
				minutes.localRotation = Quaternion.Euler (0f, 0f, analogueMinutes * -minutesToDegrees);
				seconds.localRotation = Quaternion.Euler (0f, 0f, analogueSeconds * -secondsToDegrees);
				}
		}

		public Signal GetTimeButtonClickedSignal
		{
			get
			{ 
				return getTimeButtonClickedSignal;
			}
		}

		public void Init()
		{
			getTimeButton.onClick.AddListener(OnGetTimeButtonClicked);
		}

		public void UpdateTime(DateTime dateTime)
		{
			time = dateTime;
			clockStart = true;
		}

		private void OnGetTimeButtonClicked()
		{
			getTimeButtonClickedSignal.Dispatch();
		}
	}
}