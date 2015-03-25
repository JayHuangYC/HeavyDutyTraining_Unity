using UnityEngine;
using System.Collections;

public class LevelSetting : MonoBehaviour {

	public int Level;
	public GameObject Object_Rotate = null;
	public GameObject Panel = null;

	public GameObject[] Options = null;
	public Material[] HighLightMats = null;
	public Material[] OriginalMats = null;
	public float[] TextDistance = null;
	public string[] Missions = null;
	public float[] Time = null;
	public int[,] Options_Selected = new int[10,5]{	
		{3,6,8,11,14},{0,1,4,5,9},{2,7,10,12,13}, /* 5 are options */
		{3,6,8,11,0},{14,0,1,4,0},{5,9,2,7,0},{10,12,13,6,0}, /* first 4 are options, last one is answer created by Randomizer*/
		{1,2,5,9,13}/*13*/,{0,4,11,12,14}/*4*/, /* 5 are options, correct answer is saved in Mission:InputAnswer */
		{1,2,3,4,0}}; /*Level 10: Stroke 1(Intake), 2(Compression), 3(Power), 4(Exhaust), last one is answer created by Randomizer*/
	public int[] Answers = null;

	public GameObject[] TransparentObjects = null;
	public Material[] TransparentMats = null;
	public UILabel[] DialogLevelLabel;
	void Awake()
	{
		//GetSetting ();
		Object_Rotate.SetActive (true);
		Panel.SetActive (true);
	}

	public void GetSetting()
	{
		if (PlayerPrefs.HasKey ("Level"))
			Level = PlayerPrefs.GetInt ("Level");
		else
			Level = 0;
		
		//Setup Dialog (Mission, Confirmation) level label
		for (int i=0; i<DialogLevelLabel.Length; i++)
						DialogLevelLabel [i].text = Level.ToString ();

	}

	public void SetSetting(int StarGet)
	{
		Debug.Log ("Leaving level" + Level);

		switch (Level)
		{
			case 1:
			{
				PlayerPrefs.SetInt ("StarL1Get", StarGet);
				break;
			}
			case 2:
			{
				PlayerPrefs.SetInt ("StarL2Get", StarGet);	
				break;
			}
			case 3:
			{
				PlayerPrefs.SetInt ("StarL3Get", StarGet);
				break;
			}
			case 4:
			{
				PlayerPrefs.SetInt ("StarL4Get", StarGet);
				break;
			}
			case 5:
			{
				PlayerPrefs.SetInt ("StarL5Get", StarGet);
				break;
			}
			case 6:
			{
				PlayerPrefs.SetInt ("StarL6Get", StarGet);
				break;
			}
			case 7:
			{
				PlayerPrefs.SetInt ("StarL7Get", StarGet);
				break;
			}
			case 8:
			{
				PlayerPrefs.SetInt ("StarL8Get", StarGet);
				break;
			}
			case 9:
			{
				PlayerPrefs.SetInt ("StarL9Get", StarGet);
				break;
			}
			case 10:
			{
				PlayerPrefs.SetInt ("StarL10Get", StarGet);
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
