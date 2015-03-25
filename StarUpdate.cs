using UnityEngine;
using System.Collections;

public class StarUpdate : MonoBehaviour {

	//public bool updateData = false;
	// Use this for initialization
	public int level;
	public string TotalKey;
	public string GetKey;

	public GameObject[] stars;

	private bool hasKeyTotal;
	private bool hasKeyGet;
	private int starTotal;
	private int starGet;
	
	void Awake()
	{


	}

	void Start () 
	{
	
		if (PlayerPrefs.HasKey (TotalKey)) 
		{
			starTotal = PlayerPrefs.GetInt (TotalKey);
			Debug.Log("Have Total Key ["+TotalKey+"] value: "+starTotal);
			hasKeyTotal = true;

			if (PlayerPrefs.HasKey (GetKey)) 
			{
				starGet = PlayerPrefs.GetInt (GetKey);
				Debug.Log("Have Get Key ["+GetKey+"] value: "+starGet);
				hasKeyGet = true;
			}
			else
			{
				hasKeyGet = false;
			}
		}
		else
		{
			Debug.Log("No Key");
			hasKeyTotal = false;
		}

		UpdateStarStatus (); 

	}
	
	// Update is called once per frame
	void UpdateStarStatus() 
	{
	
		if(hasKeyTotal)
		{
			//stars.GetComponentInChildren<UITexture>().color = Color.yellow;
			for(int i=0; i<stars.Length; i++)
			{
				stars[i].SetActive(false);
			}

			for(int j=0; j<starTotal; j++)
			{
				stars[j].SetActive(true);
				stars[j].GetComponentInChildren<UITexture>().color = new Color(0.0f, 0.0f, 0.0f, 0.4f);//Color.gray;
			}

			if(hasKeyGet && starGet<=starTotal)
			{
				for(int k=0; k<starGet; k++)
				{
					stars[k].GetComponentInChildren<UITexture>().color = Color.white;
				}
			}
		}
	}
}
