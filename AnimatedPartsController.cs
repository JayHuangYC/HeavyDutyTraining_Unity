using UnityEngine;
using System.Collections;

public class AnimatedPartsController : MonoBehaviour {

	public int speed;
	private int _speed;
	public LevelSetting Setting = null;

	private int level;
	public AudioClip Noise = null;

	// Use this for initialization
	void Start () {
		transform.GetComponent<Animator> ().Play ("Animated1");
		Pause ();//Play ();
		level = Setting.Level;
	}
	

	public void Pause()
	{
		transform.GetComponent<Animator> ().speed = 0;
		//NGUITools.PlaySound(Noise,0.1f)
	
	}

	public void Play()
	{	
	
		transform.GetComponent<Animator> ().speed = 1.5f;
		//NGUITools.PlaySound(Noise,1.0f)
	}

	public void Faster()
	{
		transform.GetComponent<Animator> ().speed = 10;
	}

	public void Slower()
	{
		transform.GetComponent<Animator> ().speed = 1;
	}

	public void Reset()
	{
		
	}

	public void Pause_3_Power()
	{
		//Debug.Log ("=== Power: "+Setting.Options_Selected[level-1,2]+" Answer:"+Setting.Options_Selected[level-1,4]);	
		if(level==10 && Setting.Options_Selected[level-1,2]==Setting.Options_Selected[level-1,4])
		{
			Pause();
		}
	}

	public void Pause_4_Exhaust()
	{
		//Debug.Log ("=== Exhaust: "+Setting.Options_Selected[level-1,3]+" Answer:"+Setting.Options_Selected[level-1,4]);	
		if(level==10 && Setting.Options_Selected[level-1,3]==Setting.Options_Selected[level-1,4])
		{
			Pause();
		}
	}

	public void Pause_1_Intake()
	{
		//Debug.Log ("=== Intake: "+Setting.Options_Selected[level-1,0]+" Answer:"+Setting.Options_Selected[level-1,4]);		
		if(level==10 && Setting.Options_Selected[level-1,0]==Setting.Options_Selected[level-1,4])
		{
			Pause();
		}
	}

	public void Pause_2_Compression()
	{
		//Debug.Log ("=== Compression: "+Setting.Options_Selected[level-1,1]+" Answer:"+Setting.Options_Selected[level-1,4]);		
		if(level==10 && Setting.Options_Selected[level-1,1]==Setting.Options_Selected[level-1,4])
		{
			Pause();
		}
	}
}
