using System;

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Clock
{
	public class DigitalClockView  : View , IClockView
    {
		public Text timeText;
        public Button getTimeButton;
        public Signal getTimeButtonClickedSignal = new Signal();

		private bool clockStart = false;

		DateTime time = DateTime.MinValue;

		void FixedUpdate ()
		{
			if (clockStart) 
			{
				time = time.AddSeconds (.02);
				timeText.text = time.ToString("hh:mm:ss tt");
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
			timeText.text = dateTime.ToString("hh:mm:ss tt");
			clockStart = true;
        }

        private void OnGetTimeButtonClicked()
        {
            getTimeButtonClickedSignal.Dispatch();
        }
  	}
}