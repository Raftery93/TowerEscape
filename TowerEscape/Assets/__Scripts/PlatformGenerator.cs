using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    GameObject clones;

    
    void Start()
    {
        //Get width for platform
        platformWidth = thePlatforms.GetComponent<BoxCollider2D>().size.y;

    }
    

    void Update()
    {
        //Get random x value between boundaries
        int randomXPos = RandomNumber(-6, 7);

        if (transform.position.y < generationPoint.position.y)
        {
            
            int pointsToAdd = 1;
            //Create switch statement for 3 platform positions
            //Create 1 or 2 platforms (Random)

            //Change position on x axis (Random number)
            transform.position = new Vector2(randomXPos,
                transform.position.y + platformWidth + distanceBetween);

            //Create platforms
            clones = Instantiate(thePlatforms, transform.position, transform.rotation);

            //Add point when platform is created
            ScoreManager.AddPoints(pointsToAdd);


        }
        //Destroy expired platforms after 30 sec
        Destroy(clones, 30);
      



    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random ran = new System.Random();
        int number = ran.Next(min, max);
        return number;
    }
}
