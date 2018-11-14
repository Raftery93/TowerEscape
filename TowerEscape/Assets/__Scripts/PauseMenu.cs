using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

	
	// Update is called once per frame
	void Update () {

        


        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

            float step = 0.00f;


            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;

        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

            float step = 0.01f;


            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        Application.LoadLevel(mainMenu);
    }

    
}
