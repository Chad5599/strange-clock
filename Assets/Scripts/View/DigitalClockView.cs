using System;

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class DigitalClockView : View
    {
        public Button getTimeButton;
        public Text time;

        public Signal getTimeButtonClickedSignal = new Signal();

        internal void Init()
        {
            getTimeButton.onClick.AddListener(OnGetTimeButtonClicked);
			UpdateTime(new DateTime());
        }

		public void UpdateTime(DateTime dateTime)
        {
			time.text = dateTime.ToString("hh:mm:ss tt");
        }

        private void OnGetTimeButtonClicked()
        {
            getTimeButtonClickedSignal.Dispatch();
        }
  	}
}