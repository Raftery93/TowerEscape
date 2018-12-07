using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadMenu : MonoBehaviour {

    //Variables
    public GameObject deadMenuCanvas;
    public static int isDead;
    public string mainMenu;
    
    void Update () {

        //Check if player is dead
        isDead = PlayerPrefs.GetInt("isDead");

        //If player is dead
        if (isDead == 1)
        {
            //Display dead menu canvas
            deadMenuCanvas.SetActive(true);
 

        }
        else
        {
            //else dont
            deadMenuCanvas.SetActive(false);


        }

    }

    //If dead menu canvas is active, and quit is selected
    public void Quit()
    {
        //Quit to main menu
        SceneManager.LoadScene(mainMenu);
    }
}
