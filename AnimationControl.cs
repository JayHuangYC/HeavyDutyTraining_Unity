using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {


	public GameObject[] Models;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{	
			Application.Quit(); 
			return;
		}

		if (Input.GetKey(KeyCode.Alpha1)) 
		{	
			Models[0].GetComponent<Animation>().Play("Model1_Animation");
			Debug.Log("Key 1 pressed");
			return;
		}

		if (Input.GetKey(KeyCode.Alpha2)) 
		{	
			Models[1].GetComponent<Animation>().Play("Model2_Animation");
			Debug.Log("Key 2 pressed");
			return;
		}
	}
}