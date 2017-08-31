using System;
using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class ClockMediator : Mediator
    {
        [Inject] public GetTimeSignal getTimeSignal { get; set; }
        [Inject] public ClockView2D view { get; set; }

        public override void OnRegister()
        {
            view.Init();
            view.getTimeButtonClickedSignal.AddListener(OnGetTimeButtonClicked);
        }

        public override void OnRemove()
        {
            view.getTimeButtonClickedSignal.RemoveListener(OnGetTimeButtonClicked);
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
