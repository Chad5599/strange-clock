using System;
using UnityEngine;

using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace Clock
{
    public class ClockContext : MVCSContext
    {
		public ClockContext(MonoBehaviour contextView) : base(contextView)
        {
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<UpdateTimeSignal>().ToSingleton();
            injectionBinder.Bind<IClockModel>().To<ClockModel>().ToSingleton();
            injectionBinder.Bind<IClockService>().To<ServerClockService>().ToSingleton();
            mediationBinder.Bind<ClockView>().To<ClockViewMediator>();
            commandBinder.Bind<PressButtonSignal>().To<GetTimeInCommand>();
        }
    }
}
