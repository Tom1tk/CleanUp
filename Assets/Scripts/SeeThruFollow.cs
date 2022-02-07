using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS NO LONGER IN USE
public class SeeThruFollow : MonoBehaviour
{
    //THIS SCRIPT IS NO LONGER IN USE
    public static int PosID = Shader.PropertyToID("_PlayerPos");
    public static int SizeID = Shader.PropertyToID("_HoleSize");
    public Material SeeThruMat;
    public Camera Camera;
    public LayerMask Mask;

    // Update is called once per frame
    void Update()
    {
        //var dir = Camera.transform.position - transform.position;
        var dir = -Camera.transform.forward;
        var ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, 3000, Mask))
        {
            SeeThruMat.SetFloat(SizeID , 1);
        }else{
            SeeThruMat.SetFloat(SizeID , 0);
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        SeeThruMat.SetVector(PosID, view);
    }
}

//THIS SCRIPT IS NO LONGER IN USE