using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [Header("Camera Reference")]
    public Camera cam;
    [Header("Player Navmesh Reference")]
    public NavMeshAgent agent;
    [Header("GameControl Reference")]
    public GameControlScript GCSref;

    void DrawPath()
    {
        var nav = GetComponent<NavMeshAgent>();
        if(nav == null || nav.path == null)
            return;
    
        var line = this.GetComponent<LineRenderer>();
        if(line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) {color = Color.yellow};
            line.startWidth =  0.5f;
            line.startColor = Color.yellow;
        }
    
        var path = nav.path;
    
        line.positionCount = path.corners.Length;
    
        for( int i = 0; i < path.corners.Length; i++ )
        {
            line.SetPosition( i, path.corners[ i ] );
        }

        /*
        Draws a yellow line from the center of the player to the clicked location with the code in the Update() below
        */
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update () 
    {
        cam = Camera.main;
        if(GCSref.gamePlaying)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
            DrawPath();

            /*
            Gets the mouse1 down to any location in screen space, 
            moves player (navmesh agent) to the clicked location on the navmesh surface
            then draws the line for player feedback
            */
        }
    }
}