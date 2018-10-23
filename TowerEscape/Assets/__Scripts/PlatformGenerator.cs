using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    // Use this for initialization
    void Start()
    {
        platformWidth = thePlatforms.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y + platformWidth + distanceBetween);

            Instantiate(thePlatforms, transform.position, transform.rotation);
        }
    }
}
