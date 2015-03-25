using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class MissingMarker : MonoBehaviour {

	public DefaultTrackableEventHandler TrackStatus = null;
	private bool tempTracked;
	public GameObject MissMarker = null;


	// Use this for initialization
	void Start () {
		tempTracked = !TrackStatus.tracked;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (TrackStatus.tracked != tempTracked) 
		{
			tempTracked = TrackStatus.tracked;
			if(TrackStatus.tracked == true)
			{
				MissMarker.GetComponentInChildren<UIPlayTween>().playDirection = Direction.Reverse;
				MissMarker.GetComponentInChildren<UIPlayTween>().Play (true);
				//MissMarker.SetActive(false);
			}
			else
			{
				//MissMarker.SetActive(true);
				MissMarker.GetComponentInChildren<UIPlayTween>().playDirection = Direction.Forward;
				MissMarker.GetComponentInChildren<UIPlayTween>().Play (true);
			}
		}
	}
}
