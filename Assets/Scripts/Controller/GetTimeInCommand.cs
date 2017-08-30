using strange.extensions.command.impl;
using UnityEngine;

public class GetTimeInCommand : Command {


	public IClockModel clockModel{ get; set; }


	public IClockService service{ get; set; }

	override public void Execute()
	{
		Retain ();
		service.GetTime().Then(OnGettingTime);

	}

	private void OnGettingTime(string status)
	{
		
		
		Release ();
	}
}
