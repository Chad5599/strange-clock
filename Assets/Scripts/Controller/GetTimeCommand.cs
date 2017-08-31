using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.signal.impl;

namespace Clock
{
    public class GetTimeCommand : Command
    {
        [Inject] public IClockModel clockModel { get; set; }
        [Inject] public IClockService clockService { get; set; }
        [Inject] public UpdateTimeSignal updateTimeSignal { get; set; }

        override public void Execute()
        {
            Retain();
            clockService.GetTime().Then(OnGetTime);
        }

        private void OnGetTime(string result)
		{
			if (result == "success") 
			{
				updateTimeSignal.Dispatch(clockModel.time);
			}

            Release();
        }
    }
}