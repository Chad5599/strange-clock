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
            //a click will be detected when the button will be pressed

            SetTime(0);
            //to give time zero in the start
        }

        public void SetTime(long value)
        {
            showTimeText.text = value.ToString();
            //to set value of text
        }

        private void onClickButton()
        {
            buttonClickedSignal.Dispatch();
            //on pressing button sending signal to mediator
        }


    }


}