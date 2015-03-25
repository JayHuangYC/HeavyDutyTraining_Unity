using UnityEngine;
using System.Collections;

public class GoToLink : MonoBehaviour {

	public string Link = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Go()
	{
		if(Link != null) Application.OpenURL (Link);
	}
}
