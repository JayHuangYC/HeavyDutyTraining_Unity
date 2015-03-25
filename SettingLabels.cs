using UnityEngine;
using System.Collections;

public class SettingLabels : MonoBehaviour {

	public GameObject[] labels = null;
	// Use this for initialization
	public bool defaultHide;

	void Start () {
	
		defaultHide = true;
		OnLabels ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnLabels()
	{
		defaultHide = !defaultHide;
		if(!defaultHide)
		{
			for(int i=0; i<labels.Length; i++)
				labels[i].SetActive(defaultHide);
		}
	}

	public void OffLabels()
	{
		//defaultHide = !defaultHide;
		if(defaultHide)
		{
			for(int i=0; i<labels.Length; i++)
				labels[i].SetActive(defaultHide);
		}
	}


}
