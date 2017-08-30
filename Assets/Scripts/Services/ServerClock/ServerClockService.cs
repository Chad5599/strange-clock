using UnityEngine;

using strange.extensions.promise.api;
using strange.extensions.promise.impl;

public class ServerClockService : IClockService
{
	public IClockModel model{ get; set; }

	private IPromise<string> promise;

	public IPromise<string> GetTime()
	{
		promise = new Promise<string>();

		ServerClockAPI.instance.SendGetTimeRequest(OnGetTime);
		return promise;
	}

	private void OnGetTime(string status)
	{
		promise.Dispatch(status);

		if (status == "success") {
			Debug.Log ("I am a success");
		} else if (status == "failure") {
			Debug.Log ("I am a failure");

		}

	}
}
