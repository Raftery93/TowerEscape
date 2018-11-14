using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float step = 0.01f;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.y += step;
        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
