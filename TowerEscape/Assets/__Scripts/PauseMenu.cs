using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    //Variables
    public string mainMenu;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    public float step = 0.0f;
    float valueToIncrease = 0.00001f;
    float saveSpeed;

    void Update () {

        //Trying to fix the camera dead menu situation
        if (step > 0.0f)
        {
            saveSpeed = step;
            PlayerPrefs.SetFloat("saveSpeed", saveSpeed);
        }

        //If game is paused
        if (isPaused) {
        
            //Display pause menu canvas
            pauseMenuCanvas.SetActive(true);
            
            //Pause player movement
            Time.timeScale = 0f;

            //Pause main camera
            step = 0.00f;
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;
        }
        else
        {
            //Disable pause menu canvas
            pauseMenuCanvas.SetActive(false);

            //Allow player movement
            Time.timeScale = 1f;

            //Speed camera movement for difficulty
            step += valueToIncrease;
            
            //Dont allow it to become to difficult
            if (step > 0.04f)
            {
                step = 0.04f;
            }

            //Move camera up gradually
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;

        }

        //If esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            step = PlayerPrefs.GetFloat("saveSpeed");

            //If game is already paused, then pause... or vice versa
            isPaused = !isPaused;
        }

    }

    //Resume game if resume is clicked
    public void Resume()
    {
        isPaused = false;
    }

    //Quit game if quick is clicked
    public void Quit()
    {
        //Load up main menu
        SceneManager.LoadScene(mainMenu);
    }

    
}
