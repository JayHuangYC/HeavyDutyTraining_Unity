using UnityEngine;
using System.Collections;

public class Topic1 : MonoBehaviour {

	public void GoTopic1() //Use Gallary Screenshot
	{
		PlayerPrefs.SetInt ("Topic", 1);
		//StartCoroutine(ScreenshotManager.Save("UNIDO", "UNIDO"));
		Application.LoadLevel ("P3_UI_Levels");
	}
}
