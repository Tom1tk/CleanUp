using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS NO LONGER IN USE
public class BlurScript : MonoBehaviour
{
    //THIS SCRIPT IS NO LONGER IN USE
    public Camera blurCam;
    public Material blurMat;
    // Start is called before the first frame update
    void Start()
    {
        if(blurCam.targetTexture != null)
        {
            blurCam.targetTexture.Release();
        }
        blurCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
        blurMat.SetTexture("_RenTex", blurCam.targetTexture);
    }

}
//THIS SCRIPT IS NO LONGER IN USE