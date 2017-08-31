using System;

using UnityEngine;

using strange.extensions.promise.api;
using strange.extensions.promise.impl;

namespace Clock
{
    public class ServerClockService : IClockService
    {
        [Inject] public IClockModel clockModel { get; set; }

        private IPromise<string> promise;

        public IPromise<string> GetTime()
        {
            promise = new Promise<string>();

            ServerClockAPI.instance.SendGetTimeRequest(OnGetTime);
            return promise;
        }

        private void OnGetTime(long milliseconds)
        {
			clockModel.time = TimeUtil.UNIX_EPOCH.AddMilliseconds(milliseconds);
            promise.Dispatch("success"); // Server result is success.
        }
    }
}
