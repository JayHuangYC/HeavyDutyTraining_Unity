using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class MissionScript : MonoBehaviour {

	private int level;
	public LevelSetting Setting = null;

	public GameObject MissionTexture = null;
	public UILabel missionLabel = null;	

	private bool[] temp = new bool[5];

	public GameObject ConfirmTexture = null;
	public UILabel confirmLabel = null;	

	public GameBtnPlay gamePlay = null;
	public GameBtnPause gamePause = null;
	public ReturnToLevels returnLevels = null;

	private int num; //OptionRandomizer default number
	public AudioClip[] RightWrong = null;

	public bool AnswerChecked;
	// Use this for initialization
	void Start () {


		SetupMission ();

		if(PlayerPrefs.HasKey("LastNum"))
			num = PlayerPrefs.GetInt("LastNum");
		else
			num = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void SetupMission ()
	{
		//Re-assure confirm texture is reversed.
//		ConfirmTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Reverse;
//		ConfirmTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
		//SetupMissionDescription
		AnswerChecked = false;
		level = Setting.Level;

		switch (level)
		{
		case 1:
		{
			missionLabel.text = Setting.Missions [level - 1];
			for(int i=0; i<5; i++)
			{
				missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,i]].transform.name;
				if(i<4)
					missionLabel.text += ", ";
				else if(i==4)
					missionLabel.text += ".";
			}
			break;
		}
		case 2:
		{
			missionLabel.text = Setting.Missions [level - 1];
			for(int i=0; i<5; i++)
			{
				missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,i]].transform.name;
				if(i<4)
					missionLabel.text += ", ";
				else if(i==4)
					missionLabel.text += ".";
			}
			break;
		}
		case 3:
		{
			missionLabel.text = Setting.Missions [level - 1];
			for(int i=0; i<5; i++)
			{
				missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,i]].transform.name;
				if(i<4)
					missionLabel.text += ", ";
				else if(i==4)
					missionLabel.text += ".";
			}
			break;
		}
		case 4:
		{
			missionLabel.text = Setting.Missions [level - 1];
			Setting.Options_Selected[level-1,4] = Setting.Options_Selected[level-1, OptionsRandomizer()];
			missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,4]].transform.name +".";
			Debug.Log("Component Number: "+Setting.Options_Selected[level-1,4]);
			Debug.Log("Component Name: "+Setting.Options[Setting.Options_Selected[level-1,4]].transform.name);
			break;
		}
		case 5:
		{
			missionLabel.text = Setting.Missions [level - 1];
			Setting.Options_Selected[level-1,4] = Setting.Options_Selected[level-1, OptionsRandomizer()];
			missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,4]].transform.name +".";
			Debug.Log("Component Number: "+Setting.Options_Selected[level-1,4]);
			Debug.Log("Component Name: "+Setting.Options[Setting.Options_Selected[level-1,4]].transform.name);
			break;
		}
		case 6:
		{
			missionLabel.text = Setting.Missions [level - 1];
			Setting.Options_Selected[level-1,4] = Setting.Options_Selected[level-1, OptionsRandomizer()];
			missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,4]].transform.name +".";
			Debug.Log("Component Number: "+Setting.Options_Selected[level-1,4]);
			Debug.Log("Component Name: "+Setting.Options[Setting.Options_Selected[level-1,4]].transform.name);
			break;
		}
		case 7:
		{
			missionLabel.text = Setting.Missions [level - 1];
			Setting.Options_Selected[level-1,4] = Setting.Options_Selected[level-1, OptionsRandomizer()];
			missionLabel.text = missionLabel.text + Setting.Options[Setting.Options_Selected[level-1,4]].transform.name +".";
			Debug.Log("Component Number: "+Setting.Options_Selected[level-1,4]);
			Debug.Log("Component Name: "+Setting.Options[Setting.Options_Selected[level-1,4]].transform.name);
			break;
		}
		case 8:
		{
			missionLabel.text = Setting.Missions [level - 1];
			break;
		}
		case 9:
		{
			missionLabel.text = Setting.Missions [level - 1];
			break;
		}
		case 10:
		{
			missionLabel.text = Setting.Missions [level - 1];
			Setting.Options_Selected[level-1,4] = Setting.Options_Selected[level-1, OptionsRandomizer()];
			Debug.Log("Stop at stroke number: "+Setting.Options_Selected[level-1,4]);
			break;
		}
			
		}
	}

	public void InputAnswer(int selection)
	{
		switch (level)
		{
			case 1:
			{
				if(selection == Setting.Options_Selected[level - 1,0]) temp[0] = true; 
				if(selection == Setting.Options_Selected[level - 1,1]) temp[1] = true; 
				if(selection == Setting.Options_Selected[level - 1,2]) temp[2] = true; 
				if(selection == Setting.Options_Selected[level - 1,3]) temp[3] = true; 
				if(selection == Setting.Options_Selected[level - 1,4]) temp[4] = true; 

				break;
			}
			case 2:
			{
				if(selection == Setting.Options_Selected[level - 1,0]) temp[0] = true; 
				if(selection == Setting.Options_Selected[level - 1,1]) temp[1] = true; 
				if(selection == Setting.Options_Selected[level - 1,2]) temp[2] = true; 
				if(selection == Setting.Options_Selected[level - 1,3]) temp[3] = true; 
				if(selection == Setting.Options_Selected[level - 1,4]) temp[4] = true; 

				break;
			}
			case 3:
			{
				if(selection == Setting.Options_Selected[level - 1,0]) temp[0] = true; 
				if(selection == Setting.Options_Selected[level - 1,1]) temp[1] = true; 
				if(selection == Setting.Options_Selected[level - 1,2]) temp[2] = true; 
				if(selection == Setting.Options_Selected[level - 1,3]) temp[3] = true; 
				if(selection == Setting.Options_Selected[level - 1,4]) temp[4] = true; 

				break;
			}
			case 4:
			{
				temp[0] = (selection == Setting.Options_Selected[level - 1,4])? true:false;	
				break;
			}
			case 5:
			{
				temp[0] = (selection == Setting.Options_Selected[level - 1,4])? true:false;	
				break;
			}
			case 6:
			{
				temp[0] = (selection == Setting.Options_Selected[level - 1,4])? true:false;	
				break;
			}
			case 7:
			{
				temp[0] = (selection == Setting.Options_Selected[level - 1,4])? true:false;	
				break;
			}
			case 8:
			{
				temp[0] = (selection == 13 /*Bearing(Top)*/)? true:false;	
				break;	
			}
			case 9:
			{
				temp[0] = (selection == 4 /*Unit Injection*/)? true:false;	
				break;	
			}
			case 10:
			{
				temp[0] = (selection == Setting.Options_Selected[level - 1,4])? true:false;
				Debug.Log("=======Level 10:"+temp[0]);
				break;
			}	
		}
	}

	public void CheckAnswer()
	{
		//
		AnswerChecked = true;

		switch (level)
		{
			case 1:
			{
				if(temp[0]&&temp[1]&&temp[2]&&temp[3]&&temp[4]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 1;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 2:
			{
				if(temp[0]&&temp[1]&&temp[2]&&temp[3]&&temp[4]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 1;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 3:
			{
				if(temp[0]&&temp[1]&&temp[2]&&temp[3]&&temp[4]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 1;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 4:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 2;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 5:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 2;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 6:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 2;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 7:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 2;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 8:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 3;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 9:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 3;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
			case 10:
			{
				if(temp[0]) 
				{
					ShowConfirmResult(true);
					returnLevels.StarGet = 3;
				}
				else
				{
					ShowConfirmResult(false);
				}
				break;
			}
		}
	}

	void ShowConfirmResult(bool completed)
	{

		//Re-assure confirm texture is reversed.
		//ConfirmTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Forward;
		ConfirmTexture.GetComponentInChildren<UIPlayTween> ().Play (true);

		if(completed)
		{
			confirmLabel.color = Color.white;
			confirmLabel.text = "CORRECT! \n MISSION COMPLETED!";
			gamePause.Enable();
			NGUITools.PlaySound(RightWrong[0]);

		}
		else if(!completed)
		{
			confirmLabel.color = Color.gray;
			confirmLabel.text = "MISSION FAILED!";
			gamePause.Enable();
			returnLevels.StarGet = 0;
			NGUITools.PlaySound(RightWrong[1]);
		}
	}
	
	public void MissionToggle()
	{
		//Re-assure confirm texture is reversed.
//		ConfirmTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Reverse;
//		ConfirmTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
//		
		Direction previousDir = MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection;
		//Hide mission, or resume!
		if(previousDir == Direction.Forward)
		{
			MissionTexture.GetComponentInChildren<TweenScale> ().duration = 0.2f;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Reverse;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
			Debug.Log ("Mission come out direction:" + MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection);
		}
		//Show mission, or pause
		else if(previousDir == Direction.Reverse)
		{
			MissionTexture.GetComponentInChildren<TweenScale> ().duration = 0.5f;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Forward;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
			Debug.Log ("Mission come out direction:" + MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection);
		}
		
	}

	public void MissionReset()
	{
		temp [0] = temp [1] = temp [2] = temp [3] = temp [4] = false;
		AnswerChecked = false;

		Direction previousDir = MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection;
		//Hide mission, or start!
		if(previousDir == Direction.Reverse)
		{
			MissionTexture.GetComponentInChildren<TweenScale> ().duration = 0.5f;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Forward;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
			Debug.Log ("Mission come out direction:" + MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection);
		}

		SetupMission ();
	}

	public void MissionResume()
	{
		Direction previousDir = MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection;
		//Hide mission, or start!
		if(previousDir == Direction.Forward)
		{
			MissionTexture.GetComponentInChildren<TweenScale> ().duration = 0.2f;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Reverse;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
			Debug.Log ("Mission come out direction:" + MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection);
		}
	}

	public void MissionPause()
	{
		Direction previousDir = MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection;
		//Hide mission, or start!
		if(previousDir == Direction.Reverse)
		{
			MissionTexture.GetComponentInChildren<TweenScale> ().duration = 0.5f;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection = Direction.Forward;
			MissionTexture.GetComponentInChildren<UIPlayTween> ().Play (true);
			Debug.Log ("Mission come out direction:" + MissionTexture.GetComponentInChildren<UIPlayTween> ().playDirection);
		}
	}

	private int OptionsRandomizer() //Randomly choose one components from array #0,#1,#2,#3, and set the value to array item #4
	{
		if(PlayerPrefs.HasKey("LastNum"))
		{
			while(num == PlayerPrefs.GetInt("LastNum"))
			{
				num = Mathf.FloorToInt(Mathf.Round (Random.Range(-0.4f, 3.4f)));
			}
			PlayerPrefs.SetInt ("LastNum", num);
		}
		else
		{
			num = Mathf.FloorToInt(Mathf.Round (Random.Range(-0.4f, 3.4f))); 
			PlayerPrefs.SetInt ("LastNum", num);
		}
		Debug.Log ("Componenet ID (0~3): " + num);

		return num;
	}
}
