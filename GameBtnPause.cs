using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class GameBtnPause : MonoBehaviour {

	public GameObject ContainTweens = null;
	public GameObject MissionBtn = null;
	public UIPlayTween playDisable = null;
	public ObjectManipulation ObjMan = null;

	public AnimatedPartsController EngineAnimation = null;
	public LevelSetting Setting = null;
	private int level;
	public UIPlayTween AnswerOptions = null;
	public TimeCountDown countDown = null;

	// Use this for initialization
	void Start () {
		level = Setting.Level;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enable()
	{
		UIPlayTween[] tweens = ContainTweens.GetComponentsInChildren<UIPlayTween> ();

		for (int i=0; i<tweens.Length; i++) 
		{
			tweens [i].Play (true);// = true;
		}

		//MissionBtn.GetComponentInChildren<MissionScript> ().MissionPause ();

		ObjMan.enableTouch = false;
		
		playDisable.playDirection = Direction.Forward;
		playDisable.Play (true);

		EngineAnimation.Pause ();

		
		if(level == 10)
		{
			AnswerOptions.playDirection = Direction.Reverse;
			AnswerOptions.Play(true);
		}

		countDown.pauseTime = true;
	}
}
