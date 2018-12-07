using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for getting the music volume ingame
public class MainMenuSound : MonoBehaviour {


    public AudioSource music;

    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
