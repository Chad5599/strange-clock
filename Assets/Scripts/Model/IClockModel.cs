using System;

namespace Clock
{
    public interface IClockModel
    {
        DateTime time { get; set; }
    }
}
