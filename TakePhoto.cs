using UnityEngine;
using System.Collections;
using System.IO;

public class TakePhoto : MonoBehaviour {

	//public Texture2D texture;
	public int savedScreenshot; //0: Default, 1: Saving, 2: Saved

	//bool savedExistingImage = false;
	public UILabel status = null;

//	public GameObject RestartBtn;
//	public GameObject TakePhotoBtn;
	void Start()
	{
		savedScreenshot = 0;
		status.text = " ";

		ScreenshotManager.ScreenshotFinishedSaving += ScreenshotSaved;	
		//ScreenshotManager.ImageFinishedSaving += ImageAssetSaved;

	}

	void Update()
	{
//		if(savedScreenshot == 1)
//		{
//			status.text = "Saving Photo...\nBrowse it at Gallery application's LKDF Interact album.";
//		}
//		else if(savedScreenshot == 2)
//		{
//			status.text = "Photo Saved!\nBrowse it at Gallery application's LKDF Interact album.";
//		}
//		else if(savedScreenshot == 0)
//		{
//			status.text = " ";
//		}
	}

	public void Taking()
	{
		savedScreenshot = 1;
		status.text = "Saving Photo...\nBrowse it at Gallery application's LKDF Interact album.";
		status.transform.GetComponentInChildren<Animation> ().Play("Appear");

		StartCoroutine(ScreenshotManager.Save("LKDF", "LKDF Interact", true));
	}

	void ScreenshotSaved(string path)
	{
		Debug.Log ("screenshot finished saving to " + path);
		savedScreenshot = 2;
//		status.text = "Photo Saved!\nBrowse it at Gallery application's LKDF Interact album.";
//		status.transform.GetComponentInChildren<Animation> ().Play("Disappear");
//		Debug.Log ("Saved!!!!!!!!!!!!!!!");
	}

	public void ShowSaved()
	{
		status.text = "Photo Saved!\nBrowse it at Gallery application's LKDF Interact album.";
		status.transform.GetComponentInChildren<Animation> ().Play("Disappear");
		Debug.Log ("Saved!!!!!!!!!!!!!!!");
	}

//	void ImageAssetSaved(string path)
//	{
//		Debug.Log (texture.name + " finished saving to " + path);
//		savedExistingImage = true;
//	}

//	void OnClick() //Use Gallary Screenshot
//	{
//		audio.Play();
//		NGUITools.SetActive(RestartBtn, false);
//		NGUITools.SetActive(TakePhotoBtn, false);
//		animation.Play();
//		StartCoroutine(ScreenshotManager.Save("MediaHub", "MediaHub"));
//
//	}
//	
//	void AfterPhotoTaking()
//	{
//		NGUITools.SetActive(RestartBtn, true);
//		NGUITools.SetActive(TakePhotoBtn, true);
//		
//	}
}
