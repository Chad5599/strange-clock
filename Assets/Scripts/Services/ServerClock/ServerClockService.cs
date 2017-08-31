using UnityEngine;

using strange.extensions.promise.api;
using strange.extensions.promise.impl;

namespace Clock
{
    public class ServerClockService : IClockService
    {
        [Inject] public IClockModel model{ get; set; }

        private IPromise<string> promise;

        public IPromise<string> GetTime()
        {
            promise = new Promise<string>();

            ServerClockAPI.instance.SendGetTimeRequest(OnGetTime);
            return promise;
        }

        private void OnGetTime(long milliseconds)
        {
            model.time = milliseconds;//saving time to model
            promise.Dispatch("success");
        }
    }
}
