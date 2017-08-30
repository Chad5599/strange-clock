using strange.extensions.promise.api;

public interface IClockService  
{
	IPromise<string> GetTime();
}