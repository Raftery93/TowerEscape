using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for getting the music volume
public class MusicManager : MonoBehaviour {

    public AudioSource music;
  
    void Start () {

       // Time.timeScale = 1f;

        music.volume = PlayerPrefs.GetFloat("MusicVolume");

    }
	
}
