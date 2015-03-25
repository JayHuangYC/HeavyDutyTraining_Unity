using UnityEngine;
using System.Collections;

public class EnableAutoFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {

		EnableContinuousAutoFocus();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//We want autofocus to be enabled when the app starts
	private void EnableContinuousAutoFocus()
	{
		/*
		if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
		{
			this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO;
			this.View.mAutoFocusSetting.Enable(true);
		}
		*/
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		Debug.Log ("FOCUS_MODE_CONTINUOUSAUTO");
	}


}


