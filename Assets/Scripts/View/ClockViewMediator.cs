using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;



namespace Clock
{

    public class ClockViewMediator : Mediator
    {
		
        [Inject] public PressButtonSignal pressButtonSignal { get; set; }
        [Inject] public ClockView view { get; set; }
       // [Inject] public UpdateTimeSignal updateTimeSignal { get; set;}

        public Signal pressSignal = new Signal();

        public override void OnRegister()
        {
            view.Init();
            //to initiate function in Clock View

            view.buttonClickedSignal.AddListener(OnPressButton);
            //on gett\ing signal call pressButton method

           // updateTimeSignal.AddListener(OnUpdateTime);

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
