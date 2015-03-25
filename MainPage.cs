using UnityEngine;
using System.Collections;

public class MainPage : MonoBehaviour {

	public void PlayTopics()
	{
		
		//PlayerPrefs.SetInt ("Level", 1);
		
		//StartCoroutine(ScreenshotManager.Save("UNIDO", "UNIDO"));
		Application.LoadLevel ("P2_UI_Topics");
	}

	public void Email()
	{
		
		Application.OpenURL("mailto:lkd-facility@unido.org?subject=Enquiry about LKDF app&body=Please provide your feedback below:");
	}

	public void Information()
	{
		Application.LoadLevel ("P2_UI_Info");//Debug.Log ("Information Page");
	}

	public void Facebook()
	{
		Application.OpenURL ("https://www.facebook.com/UNIDO.HQ");
	}


}
