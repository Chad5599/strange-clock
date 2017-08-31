using strange.extensions.signal.impl;

namespace Clock
{
    public class GetTimeSignal : Signal {}
    public class UpdateTimeSignal : Signal<long> {}
}