using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestTime : MonoBehaviour {


	public IClockService serviceInstance = new ServerClockService ();


	public void PressButton () {
		serviceInstance.GetTime ();
	}
	

}
