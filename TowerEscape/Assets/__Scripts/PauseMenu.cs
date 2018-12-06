using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

    public float step = 0.0f;
    float valueToIncrease = 0.00001f;
    float saveSpeed;


    // Update is called once per frame
    void Update () {

        if (step > 0.0f)
        {
            saveSpeed = step;
            PlayerPrefs.SetFloat("saveSpeed", saveSpeed);
            Debug.Log(saveSpeed);
        }

        if (isPaused) {
        
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

            step = 0.00f;


            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;

        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

            step += valueToIncrease;

           // Debug.Log("step: "+step);

            if (step > 0.04f)
            {
                step = 0.04f;
            }


            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            step = PlayerPrefs.GetFloat("saveSpeed");
            isPaused = !isPaused;
        }

    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        //Application.LoadLevel(mainMenu);
        SceneManager.LoadScene(mainMenu);
    }

    
}
