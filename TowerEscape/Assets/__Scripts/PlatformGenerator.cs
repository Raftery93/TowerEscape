﻿using System.Collections;
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

        int randomXPos = RandomNumber(-6, 7);

        if (transform.position.y < generationPoint.position.y)
        {
            //Create switch statement for 3 platform positions
            //Create 1 or 2 platforms (Random)

            //Change position on x axis (Random number)
            transform.position = new Vector2(randomXPos,
                transform.position.y + platformWidth + distanceBetween);

            Instantiate(thePlatforms, transform.position, transform.rotation);

        }
    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random ran = new System.Random();
        int number = ran.Next(min, max);
        return number;
    }
}
