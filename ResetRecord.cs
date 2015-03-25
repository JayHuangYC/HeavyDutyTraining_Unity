using UnityEngine;
using System.Collections;

public class ResetRecord : MonoBehaviour {

	public UILabel ClearMessage = null;
	public UIPlayTween Window = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset()
	{
		Debug.Log("Reset !");

		if(PlayerPrefs.HasKey ("Level"))
		{
			ClearMessage.text = "Record Cleared !";
			Window.Play(true);
			PlayerPrefs.DeleteAll();

			Debug.Log("Record Cleared!");
		}
		else
		{
			ClearMessage.text = "No Record !";
			Window.Play(true);
			Debug.Log("No Record !");
		}
	}
}
