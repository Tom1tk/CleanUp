using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Variables")]
    public bool paused = false;
    [Header("GameControl Reference")]
    public GameControlScript GCSref;
    [Header("Canvas Object References")]
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject pauseButton;
    public GameObject zoomButton;
    public Slider PBar;
    public GameObject PercentageBar;
    public TextMeshProUGUI Percentage;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
    //simple quit button, ur welcome lol ;)
    
    public void Pause()
    {
        paused=!paused;
            
        switch(paused)
        {
            case true:
                Time.timeScale = 0;
                break;

            case false:
                Time.timeScale = 1;
                break;
        }
        if(GCSref.gamePlaying)
        {
            Debug.Log("Pause button pressed, paused = " + paused);
            pauseScreen.SetActive(paused);
            pauseButton.SetActive(!paused);
        }

        /*
        Pause() method toggles the pause state using booleans to freeze or unfreeze time
        and enable or disable certain UI elements like the pause button and screen
        */
    }

    public void Update()
    {
        PBar.value = GCSref.DustCollected;
        Percentage.text = (GCSref.DustCollected/50f)*100f + "%";

        PercentageBar.SetActive(GCSref.gamePlaying);
        zoomButton.SetActive(GCSref.gamePlaying);
        
        if (GCSref.DustCollected >= 50f && GCSref.won==false)
        {
            winScreen.SetActive(true);
            GCSref.won = true;
        }

        /*
        Updates the percentage number and bar each frame,
        sets the UI components based on if the game is being played
        and also updates win condition so the game can be completed
        */
    }
}
