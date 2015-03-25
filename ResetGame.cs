using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {

	public ObjectManipulation ObjManipulation = null;
	public MissionScript Mission = null;
	public TimeCountDown countDown = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset()
	{
		ObjManipulation.ResetOptions ();
		Mission.MissionReset ();
		countDown.pauseTime = true;
		countDown.Reset ();
	}
}
