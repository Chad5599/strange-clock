using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.signal.impl;



namespace Clock
{

    public class GetTimeInCommand : Command
    {
		
	
        [Inject] public IClockModel clockModel{ get; set; }
        [Inject] public IClockService service{ get; set; }
        [Inject] public UpdateTimeSignal updateTimeSignal { get; set;}

        override public void Execute()
        {
			
			
            Retain();
            service.GetTime().Then(OnGettingTime);

        }

        private void OnGettingTime(string status)
        {

            Debug.Log("The time is : " + clockModel.time);
		
            updateTimeSignal.Dispatch(clockModel.time);
            //getTimeSignal.Dispatch(clockModel.time);
            //dispatching signal to mediator of view
		
		
            Release();
        }
    }


}