using UnityEngine;
using System.Collections;

//To Level 1 to 10
public class Level1 : MonoBehaviour {

	public UILabel lv1_lab;

	void Awake()
	{
		if (PlayerPrefs.HasKey ("Topic")) 
		{
			//int topic = PlayerPrefs.GetInt ("Topic");

		}
		else
		{
			//Debug.Log("No Key");
		}	

	}

	public void GoLevel1() 
	{
		PlayerPrefs.SetInt ("Level", 1);
		//StartCoroutine(ScreenshotManager.Save("UNIDO", "UNIDO"));
		Application.LoadLevel ("P3_UI_Levels_Async");
	}

	public void GoLevel2() 
	{	
		PlayerPrefs.SetInt ("Level", 2);	
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel3() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 3);		
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel4() //Use Gallary Screenshot
	{
		PlayerPrefs.SetInt ("Level", 4);		
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel5() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 5);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel6() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 6);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel7() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 7);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel8() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 8);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel9() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 9);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}
	
	public void GoLevel10() //Use Gallary Screenshot
	{		
		PlayerPrefs.SetInt ("Level", 10);
		Application.LoadLevel ("P3_UI_Levels_Async");
	}

	public void GoLevelFuture() //Use Gallary Screenshot
	{		
//		PlayerPrefs.SetInt ("Level", 10);
//		Application.LoadLevel ("P4_AR_L1");
	}

}
