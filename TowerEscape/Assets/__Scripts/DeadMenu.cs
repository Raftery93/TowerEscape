using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadMenu : MonoBehaviour {


    public GameObject deadMenuCanvas;
    public static int isDead;
    public string mainMenu;

    // Update is called once per frame
    void Update () {

        isDead = PlayerPrefs.GetInt("isDead");

        if (isDead == 1)
        {
            deadMenuCanvas.SetActive(true);
 

        }
        else
        {
            deadMenuCanvas.SetActive(false);


        }

    }

    public void Quit()
    {

        //Application.LoadLevel(mainMenu);
        SceneManager.LoadScene(mainMenu);
    }
}
