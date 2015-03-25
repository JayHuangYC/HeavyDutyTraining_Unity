using UnityEngine;
using System.Collections;

public class StarInitialization : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		//Testing
		PlayerPrefs.SetInt ("StarL1Total", 1);
		PlayerPrefs.SetInt ("StarL2Total", 1);
		PlayerPrefs.SetInt ("StarL3Total", 1);
		PlayerPrefs.SetInt ("StarL4Total", 2);
		PlayerPrefs.SetInt ("StarL5Total", 2);
		PlayerPrefs.SetInt ("StarL6Total", 2);
		PlayerPrefs.SetInt ("StarL7Total", 2);
		PlayerPrefs.SetInt ("StarL8Total", 3);
		PlayerPrefs.SetInt ("StarL9Total", 3);
		PlayerPrefs.SetInt ("StarL10Total", 3);
	}
	
}
