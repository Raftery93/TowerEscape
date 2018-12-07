using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public AudioSource music;
    public Slider volume;

	// Use this for initialization
	void Start () {
        //Get volume from playerprefs
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }
	
	// Update is called once per frame
	void Update () {
        //Get value from slider
        music.volume = volume.value;
        VolumePrefs();
    }

    public void VolumePrefs()
    {
        //Set volume
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
    }
}
