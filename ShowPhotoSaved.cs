using UnityEngine;
using System.Collections;

public class ShowPhotoSaved : MonoBehaviour {

	public UILabel status = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowSaved()
	{
		status.text = "Photo Saved!\nBrowse it at Gallery application's LKDF Interact album.";
		status.transform.GetComponentInChildren<Animation> ().Play("Disappear");
		Debug.Log ("Saved!!!!!!!!!!!!!!!");
	}
}
