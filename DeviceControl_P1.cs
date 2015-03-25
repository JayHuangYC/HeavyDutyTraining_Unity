using UnityEngine;
using System.Collections;

public class DeviceControl_P1 : MonoBehaviour {

	//public ReturnToLevels returnLevels = null;
	public AudioClip click = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		Debug.Log("Android");
	
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu) || Input.GetKey(KeyCode.Return)) 
		{	
			NGUITools.PlaySound(click);
			Application.Quit(); 
			return;
		}


//		if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Escape))
//		{
//			NGUITools.PlaySound(click);
//			returnLevels.ReturnLevels();
//		}
		#endif
	}

	public void Exit()
	{
		NGUITools.PlaySound(click);
		Application.Quit(); 
		return;
	}

}
