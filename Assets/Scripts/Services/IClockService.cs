using strange.extensions.promise.api;

namespace Clock
{
    public interface IClockService
    {
        IPromise<string> GetTime();
    }
}