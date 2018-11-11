using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource music;
    // Use this for initialization
    void Start () {

       // Time.timeScale = 1f;

        music.volume = PlayerPrefs.GetFloat("MusicVolume");

    }
	
}
