using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
	public class analogueClock3DView : View
	{
		public Button getTimeButton;
		public Signal getTimeButtonClickedSignal = new Signal();
		public Transform hours, minutes, seconds;

		private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;
		private bool clockStart = false;

		DateTime time = DateTime.MinValue;

		void Update ()
		{
			if (clockStart) 
			{
				time = time.AddSeconds (.02);
				hours.localRotation = Quaternion.Euler (0f, 0f, time.Hour * -hoursToDegrees);
				minutes.localRotation = Quaternion.Euler (0f, 0f, time.Minute * -minutesToDegrees);
				seconds.localRotation = Quaternion.Euler (0f, 0f, time.Second * -secondsToDegrees);
			}
		}

		internal void Init()
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