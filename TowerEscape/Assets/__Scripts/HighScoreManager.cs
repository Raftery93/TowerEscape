using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    public static int highScore;

    Text text;



    void Start()
    {
        text = GetComponent<Text>();

        highScore = PlayerPrefs.GetInt("HighScore");

        text.text = "" + highScore;
    }


}
