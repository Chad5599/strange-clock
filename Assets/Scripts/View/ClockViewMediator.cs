using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class ClockViewMediator : Mediator
    {
        [Inject] public PressButtonSignal pressButtonSignal { get; set; }
        [Inject] public ClockView view { get; set; }
 
        public Signal pressSignal = new Signal();

        public override void OnRegister()
        {
            view.Init();
            view.buttonClickedSignal.AddListener(OnPressButton);
        }

        public override void OnRemove()
        {
            view.buttonClickedSignal.RemoveListener(OnPressButton);
        }

        private void OnPressButton()
        {
            pressButtonSignal.Dispatch();
        }

        [ListensTo(typeof(UpdateTimeSignal))]
        private void OnUpdateTime(long milliseconds)
        {
            view.SetTime(milliseconds);
        }
    }
}
