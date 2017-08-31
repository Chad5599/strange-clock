using System;

using strange.extensions.command.impl;

namespace Clock
{

    public interface IClockModel
    {
        long time { get; set; }
    }

}
