using UnityEngine;
using System.Collections;

public class ObjectManipulation : MonoBehaviour {

	//this game object's Transform
	public int level;
	private Transform ARCamTransform;
	private float _length = 1000.0f;
	//public Ray ray;
	private bool _mobile;

	public UILabel ObjName;
	public UILabel[] ObjNames;

	public Texture crossHair;
	public GameObject crossHair3D;
	public GameObject crossHair3D_Feedback;
	private Rect ch_pos;
	private Transform pickedObject = null;
	private bool pressed;
	private float screenPrev = 0; 
	private float rot_degree = 0;
	public float sensitivity = 50;
	
	public GameObject Text3D;
	public GameObject[] InteractObjects;
	public GameObject[] InteractObjectsText3Ds;
	public GameObject[] InteractObjectsText3DPrefabs;

	public LevelSetting Setting = null;
	private int objNumber;
	private bool noTouchMoved = false;

	public MissionScript Mission = null;
	private Color outlineColor = new Color(0.0f,0.0f,0.0f,1.0f); 

	public bool enableTouch;

	public AudioClip SwipeAudioClip;
	public AudioClip ClickAudioClip;

	private bool firstTime;

	void Awake () 
	{
		//get the attached Transform component
		ARCamTransform = this.GetComponent<Transform> ();
		pressed = false;
		firstTime = true;
		GetSetting ();
		level = Setting.Level;//Must be ready after GetSetting()
		PrepareObjectsText3D ();
		saveOutlineColor ();
		PrepareOptions ();
		enableTouch = false;

	}

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		Debug.Log("Unity Editor");
		#endif
		
		#if UNITY_IPHONE
		Debug.Log("Iphone");
		#endif

		#if UNITY_ANDROID
		Debug.Log("Android");
		#endif

		#if UNITY_STANDALONE_OSX
		Debug.Log("Stand Alone OSX");
		#endif
		
		#if UNITY_STANDALONE_WIN
		Debug.Log("Stand Alone Windows");
		#endif


//		if (Application.platform == RuntimePlatform.Android) 
//		{
//			_mobile = true;				
//			ObjName.text = "Android";
//		}
//		else
//		{
//			_mobile = false;
//			ObjName.text = "Not Android";
//		}
//		Debug.Log("RuntimePlatform Android? " + _mobile);
		
		//crossHair3D.GetComponent<Animator> ().Play("CrossHair_Center");

		crossHair3D.GetComponent<Animator> ().Play("Trigger");


		Debug.Log ("Level get in ObjectManipulation: " + Setting.Level);

	}
	



	// Update is called once per frame
	void Update() {
		if(!enableTouch) return;

		#if UNITY_ANDROID
	

		foreach (Touch touch in Input.touches)// && (Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetTouch (0).phase == TouchPhase.Moved)) {  //
		{
			//Use touch to create Ray
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			Debug.Log("Touch phase began at: " + touch.position);
	
			if(touch.phase == TouchPhase.Began)
			{
				noTouchMoved = true;

				//Object Rotation
				RaycastHit hit_o = new RaycastHit();
				if (Physics.Raycast (ray, out hit_o, _length, 1 << 9))
				{
					pickedObject = hit_o.transform.parent.parent;
				}
				else
				{
					pickedObject = null;
				}


			}
			else if ((touch.phase == TouchPhase.Ended) && noTouchMoved)  //.Began
			{
				//Crosshair positioning
				crossHair3D_Feedback.transform.parent.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane+0.1f));

				//Debug.Log("Detect Touch x: "+touch.position.x);

				//float temp = touch.position.x/Screen.width;
				//ObjName.text = temp.ToString();//touch.position.x.ToString();

				if(touch.position.x/Screen.width < 0.875f)
				{
					//Object Interaction
					RaycastHit hit = new RaycastHit();

					if (Physics.Raycast (ray, out hit, _length, 1 << 8)) 
					{
						if(hit.transform.gameObject.tag == "Obj_Interact")
						{
								
							for(int i=0; i< objNumber; i++)
							{
								if(hit.collider.transform == InteractObjects[i].transform)
								{
									crossHair3D_Feedback.GetComponent<Animator> ().Play("Trigger");

									//InteractObjects[i].renderer.material = Setting.HighLightMats[i];
									if(level==4||level==5||level==6||level==7||level==8||level==9||level==10)
									{
										ResetOptions();
									}
									
									if(level==1||level==2||level==3||level==8||level==9||level==10)
									{
										InteractObjectsText3Ds[i].SetActive(true);
									}

									InteractObjects[i].renderer.material.SetColor("_OutlineColor", new Color(1.0F, 0.5F, 0.0F, 0.5F));

									Debug.Log ("Option Hitted: "+i);
									Mission.InputAnswer(i);

									//trigger click audio
									NGUITools.PlaySound(ClickAudioClip, 1.0f, 1.0f);
								}
							}
						}
						else
						{
							//crossHair3D.transform.position = ray.origin;
							crossHair3D_Feedback.GetComponent<Animator> ().Play("Trigger");
						}
					}
				}

			
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				noTouchMoved = false;

				if (pickedObject != null)
				{
					Vector2 screenDelta = touch.deltaPosition;
					float halfScreenWidth = 0.5f * Screen.width;
//					float halfScreenHeight = 0.5f * Screen.height;
					
					float dx = screenDelta.x / halfScreenWidth;
//					float dy = screenDelta.y / halfScreenHeight;

					Vector3 objectToCamera = pickedObject.transform.position - Camera.main.transform.position;
					float distance = objectToCamera.magnitude;
					
					//Convert object World position to display position
					//Compare the y value to decide the rotation direction
					if(touch.position.y > Camera.main.WorldToScreenPoint(pickedObject.transform.position).y)
					{	
						pickedObject.Rotate(0, dx*distance*sensitivity, 0);
//						ObjName.text = "Top " +touch.position.y+" - "+Camera.main.ScreenToWorldPoint(pickedObject.transform.position).y;
					}
					else
					{
						pickedObject.Rotate(0, -dx*distance*sensitivity, 0);
//						ObjName.text = "Down " +touch.position.y+" - "+Camera.main.ScreenToWorldPoint(pickedObject.transform.position).y;
					}
				}

				//trigger swipe audio
				//NGUITools.PlaySound(SwipeAudioClip, 0.2f, 2.0f);
			}
			else
			{

			}
		}
		#endif

		#if UNITY_EDITOR

			Ray ray_e = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.DrawRay (ray_e.origin, ray_e.direction * _length, Color.yellow);
			//ch_pos = new Rect(Input.mousePosition.x - Screen.width/(15*2), Screen.height-(Input.mousePosition.y + Screen.width/(15*2)), Screen.width/15, Screen.width/15);
			RaycastHit hit_e = new RaycastHit();
			RaycastHit hit_r = new RaycastHit();
			

			if (Input.GetMouseButtonDown(0))
			{
				
				if (Physics.Raycast (ray_e.origin, ray_e.direction, out hit_e, _length, 1 << 8)) 
				{
					if(hit_e.transform.gameObject.tag == "Obj_Interact")
					{
					//Convert screen position to World position to display cross hair in 3D
					crossHair3D_Feedback.transform.parent.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y , Camera.main.nearClipPlane));
					
					if(Input.mousePosition.x < 370.0f)
					{
						ObjName.text = Input.mousePosition.x.ToString();;

						// = hit_e.transform.position;
						//hit_e.transform.gameObject.tag = "Obj_Static";
						
	//						for(int i=0; i< objNumber; i++)
	//						{
	//							
	//							InteractObjects[i].renderer.material = Setting.OriginalMats[i];
	//							InteractObjectsText3Ds[i].SetActive(false);
	//						}

						for(int i=0; i< objNumber; i++)
						{
							if(hit_e.collider.transform == InteractObjects[i].transform)
							{
								crossHair3D_Feedback.GetComponent<Animator> ().Play("Trigger");

								//InteractObjects[i].renderer.material = Setting.HighLightMats[i];
								if(level==4||level==5||level==6||level==7||level==8||level==9||level==10)
								{
									ResetOptions();
								}

								if(level==1||level==2||level==3||level==8||level==9||level==10)
								{
								   	InteractObjectsText3Ds[i].SetActive(true);
								}

								InteractObjects[i].renderer.material.SetColor("_OutlineColor", new Color(1.0F, 0.5F, 0.0F, 0.5F));

								Debug.Log ("Option Hitted: "+i);
								Mission.InputAnswer(i);

								//trigger click audio
								NGUITools.PlaySound(ClickAudioClip, 1.0f, 1.0f);
								
							}
						}
					}
				}
				
				pressed = true;

				if(Physics.Raycast (ray_e.origin, ray_e.direction, out hit_r, _length, 1 << 9)) 
				{
					//screenPrev = Input.mousePosition.x;
					float rot_Y = hit_r.transform.parent.parent.rotation.y; //+= rot_Y;
					rot_degree = 2 * rot_Y * Mathf.Rad2Deg;
					Debug.Log ("rot_degree: " + rot_degree);

				}
			}

			}

			if (Input.GetMouseButtonUp(0))
			{
				pressed = false;
			}

			//Only collide with Obj_Rotate layer for triggering rotation
			if (pressed)
			{
				
				if(Physics.Raycast (ray_e.origin, ray_e.direction, out hit_r, _length, 1 << 9)) 
				{
					
//					float screenDelta = Input.mousePosition.x - screenPrev;
//					float halfScreenWidth = 0.5f * Screen.width;
//					float halfScreenHeight = 0.5f * Screen.height;
//					
//					float dx = screenDelta / halfScreenWidth;
//					Vector3 objectToCamera = hit_r.transform.position - Camera.main.transform.position;
//					float distance = objectToCamera.magnitude;
//					float rot_Y = -dx*distance;
				}
			}
		#endif

		//Debug.Log
	}

	private void GetSetting()
	{
		Setting.GetSetting ();
	}

	//Attach Text3D prefab under each InteractObjectsText3Ds during Awake state
	private void PrepareObjectsText3D()
	{
		//Get setting 
		objNumber = Setting.Options.Length;
		InteractObjects = new GameObject[objNumber];
		InteractObjectsText3Ds = new GameObject[objNumber];
		InteractObjectsText3DPrefabs = new GameObject[objNumber];
		Setting.OriginalMats = new Material[objNumber];

		InteractObjectsText3Ds = Setting.Options;


		Debug.Log ("InteractObjects.Length= " + InteractObjects.Length);


		for( int i=0; i < objNumber; i++)
		{
			//Assign InteractObject for parent of InteractObjectText3Ds
			InteractObjects[i] = InteractObjectsText3Ds[i].transform.parent.gameObject;

			InteractObjectsText3DPrefabs[i] = Instantiate(Text3D) as GameObject;

			InteractObjectsText3DPrefabs[i].transform.parent = InteractObjectsText3Ds[i].transform;
			InteractObjectsText3DPrefabs[i].transform.localPosition = Vector3.zero;
			InteractObjectsText3DPrefabs[i].transform.GetChild (0).transform.localPosition = new Vector3 (0, 0, 10);
			InteractObjectsText3DPrefabs[i].transform.Rotate(Vector3.zero);

			//Save material reference to setting
			Setting.OriginalMats[i] = InteractObjects[i].renderer.material;
		}
	}

	
	public void saveOutlineColor()
	{
		outlineColor = Setting.HighLightMats[0].GetColor("_OutlineColor");
	}

	private void PrepareOptions()
	{
		if(level==1 || level==2 || level==3 || level==8 || level==9 )
		{
			for (int i=0; i < objNumber; i++) 
			{
				Debug.Log ("Setting.Level #: "+level);
				//Assign Obj_Interact tag to InteractObjects

				if(i == Setting.Options_Selected[level-1,0] ||
				   i == Setting.Options_Selected[level-1,1] ||
				   i == Setting.Options_Selected[level-1,2] ||
				   i == Setting.Options_Selected[level-1,3] ||
				   i == Setting.Options_Selected[level-1,4])
				{
					InteractObjects [i].layer = 8;
					InteractObjects [i].tag = "Obj_Interact";
					InteractObjects [i].renderer.material = Setting.HighLightMats[i];
					InteractObjects [i].renderer.material.SetColor("_OutlineColor", outlineColor);

					InteractObjectsText3Ds[i].SetActive(firstTime);

					//outlineColor = InteractObjects [i].renderer.material.GetColor("_OutlineColor");
					Debug.Log ("-----Options: #"+i);
				}
			}
		}
		else if(level==10)
		{
			InteractObjects [8].layer = 8;
			InteractObjects [8].tag = "Obj_Interact";
			InteractObjects [8].renderer.material = Setting.HighLightMats[8];
			InteractObjects [8].renderer.material.SetColor("_OutlineColor", outlineColor);
			
			InteractObjectsText3Ds[8].SetActive(firstTime);
		}
		else //For level 4, 5, 6, 7, only first 4 options need to be highlighted.
		{
			for (int i=0; i < objNumber; i++) 
			{
				Debug.Log ("Setting.Level #: "+level);
				//Assign Obj_Interact tag to InteractObjects
				
				if(i == Setting.Options_Selected[level-1,0] ||
				   i == Setting.Options_Selected[level-1,1] ||
				   i == Setting.Options_Selected[level-1,2] ||
				   i == Setting.Options_Selected[level-1,3])
				{
					InteractObjects [i].layer = 8;
					InteractObjects [i].tag = "Obj_Interact";
					InteractObjects [i].renderer.material = Setting.HighLightMats[i];
					InteractObjects [i].renderer.material.SetColor("_OutlineColor", outlineColor);

					InteractObjectsText3Ds[i].SetActive(firstTime);
//					outlineColor = InteractObjects [i].renderer.material.GetColor("_OutlineColor");
					Debug.Log ("Options: #"+i);
				}
			}
		}

	}


	public void ResetOptions()
	{
		firstTime = false;
		PrepareOptions ();
	}

	void OnGUI()
	{
		//GUI.DrawTexture (ch_pos, crossHair);

	}
}
