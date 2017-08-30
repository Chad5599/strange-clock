using System;
using System.Collections;

using UnityEngine;

using TurboLabz.Gamebet;

public class ServerClockAPI
{
	public static ServerClockAPI instance = new ServerClockAPI();

	private IRoutineRunner routineRunner = new NormalRoutineRunner();
	private Action<string> successCallback; 

	public void SendGetTimeRequest(Action<string> successCallback)
	{
		this.successCallback = successCallback;
		routineRunner.StartCoroutine(GetTimeCR());
	}

	private IEnumerator GetTimeCR()
	{
		yield return new WaitForSeconds(.05f);
		DateTime time = DateTime.Now;
		yield return new WaitForSeconds(.05f);

		DateTime dt1970 = new DateTime(1970, 1, 1);
		long milliseconds = (long)(time - dt1970).TotalMilliseconds;

		successCallback("success");

	}
}
