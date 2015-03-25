using UnityEngine;
using System.Collections;

public class ReturnToLevelsAsync : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Application.LoadLevelAsync ("P4_AR_L1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnLevels()
	{
		Application.LoadLevel ("P3_UI_Levels");
	}
}
