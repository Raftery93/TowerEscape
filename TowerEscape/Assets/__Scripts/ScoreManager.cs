using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    Text text;

    public static int highScore;

    void Start()
    {
        text = GetComponent<Text>();

        score = -3;

        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        text.text = "" + score;
        HighScorePrefs();
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;

    }

    public void HighScorePrefs()
    {
        Debug.Log("In highScorePrefs Score:" + score + "HighScore:" + highScore);
        if (score > highScore)
        {
            Debug.Log("In if: Score:" + score);
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
