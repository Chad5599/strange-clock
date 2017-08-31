using System;

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class ClockView : View
    {
        public Button getTimeButton;
        public Text time;

        public Signal getTimeButtonClickedSignal = new Signal();

        internal void Init()
        {
            getTimeButton.onClick.AddListener(OnGetTimeButtonClicked);
            UpdateTime(0);
        }

        public void UpdateTime(long value)
        {
            time.text = value.ToString();
        }

        private void OnGetTimeButtonClicked()
        {
            getTimeButtonClickedSignal.Dispatch();
        }
  	}
}