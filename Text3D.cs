using UnityEngine;
using System.Collections;

public class Text3D : MonoBehaviour {


	public Transform target;

	void Awake()
	{
		target = Camera.main.transform;
	}
	// Use this for initialization
	void Start () {
//		Debug.Log ("Get Parent Name: " + transform.parent.name);
		transform.GetChild(0).GetComponent<TextMesh>().text = transform.parent.name;
		//Debug.Log ("Get Child Text3D text: " + transform.GetChild(0).GetComponent<TextMesh>().text);

		//Set Tag to inactive by default
		transform.parent.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
//		transform.LookAt (target, target.up);
		transform.LookAt( Camera.main.transform, Camera.main.transform.up);
	}
}
