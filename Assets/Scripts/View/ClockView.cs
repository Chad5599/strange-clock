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
        public Text showTimeText;

        public Signal buttonClickedSignal = new Signal();

        internal void Init()
        {
            getTimeButton.onClick.AddListener(onClickButton);
            SetTime(0);
        }

        public void SetTime(long value)
        {
            showTimeText.text = value.ToString();
        }

        private void onClickButton()
        {
            buttonClickedSignal.Dispatch();
        }
  	}
}