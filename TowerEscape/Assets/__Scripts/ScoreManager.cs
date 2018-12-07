using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used to manage the score / highscore
public class ScoreManager : MonoBehaviour {

    public static int score;

    Text text;

    public static int highScore;

    void Start()
    {
        //Get handle to ingame text
        text = GetComponent<Text>();

        //Initiatalise score
        score = -3;

        //Get highscore from playerprefs
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    
    void Update()
    {
        //Constantly update score and highscore
        text.text = "" + score;
        HighScorePrefs();
    }

    //Increment score
    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;

    }

    public void HighScorePrefs()
    {
        //Check highscore against score to get new highscore
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
