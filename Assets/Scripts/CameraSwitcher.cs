using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS NO LONGER IN USE
public class CameraSwitcher : MonoBehaviour
{
    public Transform Player;
    public Camera MainCam, FollowCam;
    public KeyCode TKey;
    public bool camSwitch = true;
    public GameControlScript GCReference;
    public GameObject zoomButton;
 
    void Start () 
    {
		FollowCam.gameObject.SetActive(false);
        MainCam.gameObject.SetActive(true);
        camSwitch = true;
        Debug.Log("test switcher code");
	}
    void Update()
    {
        if (Input.GetKeyDown(TKey) && GCReference.gamePlaying)
        {
            Zoom();
        }
    }

    public void Zoom()
    {
        camSwitch = !camSwitch;
        FollowCam.gameObject.SetActive(!camSwitch);
        MainCam.gameObject.SetActive(camSwitch);
    }
}
//THIS SCRIPT IS NO LONGER IN USE