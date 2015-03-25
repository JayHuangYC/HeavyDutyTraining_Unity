using UnityEngine;
using System.Collections;


public class Level10Options : MonoBehaviour {

	public LevelSetting Setting = null;
	public MissionScript Mission = null;
	private int level;
	public int OptionNumber;
	public UILabel[] labels;
	// Use this for initialization
	void Start () {
		level = Setting.Level;
	
	}

	public void InputAnser()
	{
		if(level == 10)
		{
			Mission.InputAnswer(OptionNumber);
			for(int i=0; i<labels.Length; i++)
			{
				if(i==OptionNumber-1) labels[i].color = new Color(1.0f,0.5f,0.0f);
				else labels[i].color = new Color(0.7f,0.7f,0.7f);
			}
		
		}
	}
}
