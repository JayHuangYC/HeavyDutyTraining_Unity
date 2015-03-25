using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class GameBtnPlay : MonoBehaviour {

	public GameObject ContainTweens = null;
	public MissionScript Mission = null;
	public UIPlayTween playDisable = null;
	public ObjectManipulation ObjMan = null;

	public AnimatedPartsController EngineAnimation = null;
	public LevelSetting Setting = null;
	private int level;
	public UIPlayTween AnswerOptions = null;
	public TimeCountDown countDown = null;

	//public MissionScript Mission = null;
	// Use this for initialization
	void Start () {
		level = Setting.Level;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enable()
	{
		Debug.Log("ContainTweens: play");
		UIPlayTween[] tweens = ContainTweens.GetComponentsInChildren<UIPlayTween> ();

		for (int i=0; i<tweens.Length; i++) 
		{
			tweens [i].Play (true);// = true;
		}

		Mission.MissionResume ();

		ObjMan.enableTouch = true;
		Debug.Log ("enableTouch = true");

		playDisable.playDirection = Direction.Reverse;
		playDisable.Play (true);


		EngineAnimation.Play ();

		if(level == 10)
		{
			AnswerOptions.playDirection = Direction.Forward;
			AnswerOptions.Play(true);
		}

		if (Mission.AnswerChecked)
		{				
			Mission.CheckAnswer ();
		}
		else
		{
			countDown.pauseTime = false;
		}

	}
}
