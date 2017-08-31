using System;
using UnityEngine;

using strange.extensions.context.impl;


namespace Clock
{
	
    public class BootstrapClock :  ContextView
    {



        void Awake()
        {
            this.context = new ClockContext(this);

        }
	
    }
		

}