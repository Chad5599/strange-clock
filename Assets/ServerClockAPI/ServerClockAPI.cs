using System;
using System.Collections;

using UnityEngine;

using TurboLabz.Gamebet;

public class ServerClockAPI
{
    public static ServerClockAPI instance = new ServerClockAPI();

    private IRoutineRunner routineRunner = new NormalRoutineRunner();
    private Action<long> successCallback;

    public void SendGetTimeRequest(Action<long> successCallback)
    {
        this.successCallback = successCallback;
        routineRunner.StartCoroutine(GetTimeCR());
    }

    private IEnumerator GetTimeCR()
    {
		// Simulating server request/responce cycle.
        yield return new WaitForSeconds(.05f);
        DateTime time = DateTime.Now;
        yield return new WaitForSeconds(.05f);

        DateTime dt1970 = new DateTime(1970, 1, 1);
        long milliseconds = (long)(time - dt1970).TotalMilliseconds;
        successCallback(milliseconds);

    }
}
