using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[Header("GameControl Reference")]
	public GameControlScript GCReference;
	[Header("Camera Reference")]
	public Camera cam;
	[Header("Player Reference")]
	public Transform target;
	[Header("Camera Variables")]
	public float cameraSize;
	public float zoomLerpSpeed = 10f;
	public float smoothing = 5f;
	public Vector3 offset = new Vector3(-10f,10f,-10f);
	public Vector3 mainCameraPos = new Vector3(-11f,13f,-11f);
    public bool following = false;

	// Use this for initialization
	void Start () 
    {
		cam = Camera.main;
		cameraSize = 12;
		offset = new Vector3(-10f,10f,-10f); 
		/*
		I experimented with doing the offset dynamically but different values in 
		the instantiation and in the inspector caused major headaches so I've hard-coded it here
		the below commented line(s) should work fine but I didn't want to risk it
		*/


		//offset = mainCameraPos - target.position;
		//Debug.Log(offset);
	}
	
	// Update is called once per frame
	void LateUpdate () //lower priority over controls and other UI updates
    {	
        if (Input.GetKeyDown(KeyCode.Space) && GCReference.gamePlaying)
        {
			Zoom();
			/*
			moving this simple one line peice of code to a method below 
			allows it to be executed via a button on the canvas via OnClick()
			The same goes for the ResetCam() method for restarting the game
			*/
        }
        
        if(following)
        {
			cameraSize = 4;
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cameraSize, Time.deltaTime * zoomLerpSpeed);
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
			/*
			simply changes the camera size to provide a smaller field of view and follows the player 
			for every frame so the camera is synced with movements 
			*/
        }else{
			cameraSize = 12;
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cameraSize, Time.deltaTime * zoomLerpSpeed);
			transform.position = Vector3.Lerp (transform.position, mainCameraPos, smoothing * Time.deltaTime);
			/*
			else, resets to default camera location and size 
			*/
		}		
	}

	public void Zoom()
	{
		following = !following;
		//toggles zoom
	}
	public void ResetCam()
	{
		following = false;
		//sets zoom, for restarting game
	}
}
/* coords of main cam
X = -11.55
Y = 11.52
Z = -11.55

 new main cam coords
-11f,13f,-11f
*/