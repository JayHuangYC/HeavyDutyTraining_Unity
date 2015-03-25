using UnityEngine;
using System.Collections;

public class ReturnToLevels : MonoBehaviour {

	// Use this for initialization
//	void OnClick()
//	{
//		Application.LoadLevel ("P3_UI_Levels");
//	}
	public int StarGet;

	public LevelSetting Setting;

	void Start()
	{
		StarGet = 0;
	}

	public void ReturnLevels()
	{
		Setting.SetSetting (StarGet);

		Application.LoadLevel ("P3_UI_Levels");
	}
}
