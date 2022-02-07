using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    [Header("Booleans")]
    public bool gamePlaying = false;
    public bool won = false;
    [Header("Object References")]
    public GameObject Player;
    public GameObject MRM;
    public GameObject StartPos;
    [Header("UI Reference")]
    public UIController UIRef;
    [Header("Particle System Reference")]
    public ParticleControl PCRef;
    [Header("Variables")]
    public float DustCollected;
    
    public void GameStart()
    {
        won = false;
        DustCollected = 0;
        StartCoroutine(moveToStart());
        gamePlaying = true;
    }

    public void GameStop()
    {
        gamePlaying = false;
        PCRef.ParticlePlayed = false;
        MRM.SetActive(true);
    }

    /*
    Methods for use in Canvas buttons to set and reset variables 
    that control many other parts of the code such as:
    -particle system being started
    -game being played
    -main menu spinning models
    -and more!
    */

    // Start is called before the first frame update
    void Start()
    {
        GameStop();
        /*
        Player.SetActive(false);
        Player.transform.position = StartPos.transform.position;
        Player.SetActive(true);
        */
    }

    IEnumerator moveToStart()
    {
        Player.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = StartPos.transform.position;
        Player.SetActive(true);

        /*
        allows for each level start position to be dynamically set with
        an empty gameobject in the editor called StartPos
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
