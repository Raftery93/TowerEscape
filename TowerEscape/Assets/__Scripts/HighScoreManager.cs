using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used for setting the highscore
public class HighScoreManager : MonoBehaviour {

    public static int highScore;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();

        highScore = PlayerPrefs.GetInt("HighScore");

        //Displays the highscore ingame
        text.text = "" + highScore;
    }


}
