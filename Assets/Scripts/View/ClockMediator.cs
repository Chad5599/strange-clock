using System;
using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class ClockMediator : Mediator
    {
        [Inject] public GetTimeSignal getTimeSignal { get; set; }
		[Inject] public IClockView view { get; set; }

        public override void OnRegister()
        {
            view.Init();
            view.GetTimeButtonClickedSignal.AddListener(OnGetTimeButtonClicked);
        }

        public override void OnRemove()
        {
            view.GetTimeButtonClickedSignal.RemoveListener(OnGetTimeButtonClicked);
        }

        private void OnGetTimeButtonClicked()
        {
            getTimeSignal.Dispatch();
        }

        [ListensTo(typeof(UpdateTimeSignal))]
		private void OnUpdateTime(DateTime dateTime)
        {
            view.UpdateTime(dateTime);
        }
    }
}
