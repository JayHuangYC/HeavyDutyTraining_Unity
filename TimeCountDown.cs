using UnityEngine;
using System.Collections;

public class TimeCountDown : MonoBehaviour {

	public LevelSetting Setting = null;
	public UILabel[] timeDisplay = null;

	private int level;
	private float timeSetting;
	public bool pauseTime;
	public MissionScript Mission;
	public AudioClip Beep;
	public bool mute;
	public UITexture soundTex = null;
	// Use this for initialization
	void Start () {

		Reset ();
		mute = true;
	}

	public void Reset()
	{
		pauseTime = true;
		level = Setting.Level;
		timeSetting = Setting.Time [level - 1];
		//		DisplayTime(timeSetting.ToString("F0"));
		DisplayTime(timeSetting);

	}

	// Update is called once per frame
	void Update () {
	
		if(pauseTime) return;

		if (timeSetting <= 0) 
		{
			//Time's Up!
			pauseTime = true;
			Mission.CheckAnswer ();
		}
		else
		{
			timeSetting -= Time.deltaTime;
			DisplayTime(timeSetting);
			AudioVisualFeedback(timeSetting);
		}
	}
	
	void DisplayTime(float _display)
	{
		timeDisplay[0].text = timeDisplay[1].text = _display.ToString("F0");
	}

	void AudioVisualFeedback(float _display)
	{
		if(Mathf.Abs (Mathf.RoundToInt(_display)-_display) < Time.deltaTime/1.5f )
		{
			this.transform.GetComponentInChildren<UIPlayAnimation>().Play(true);
			if(!mute) NGUITools.PlaySound(Beep, 0.1f);
			//Debug.Log("!!!!!!!!!!!!!!!");
		}
	}

	public void MuteBeep()
	{
		mute = !mute;
		soundTex.color = mute? new Color(0.0f,0.0f,0.0f,0.4f) : new Color(1.0f,1.0f,1.0f,1.0f); //Yes:Gray, No: white 
	}

}
