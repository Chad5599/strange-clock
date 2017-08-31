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

            // bind signal command binder
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }


	
        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<UpdateTimeSignal>().ToSingleton();
            //bind signal to mediator
            injectionBinder.Bind<IClockModel>().To<ClockModel>().ToSingleton();
            //bind Iclock interface class with concrete class ClockModel
            injectionBinder.Bind<IClockService>().To<ServerClockService>().ToSingleton();
            //bind interface class IclockService with concrete ServerClockService
            mediationBinder.Bind<ClockView>().To<ClockViewMediator>();
            //Bind mediator class ClockViewMediator with View Class ClockView
            commandBinder.Bind<PressButtonSignal>().To<GetTimeInCommand>();
            //bind signal from class to command

	
        }







    }


}
