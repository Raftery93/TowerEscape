using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour {

    public GameObject thePoints;
    public Transform generationPoint;
    public float distanceBetween;
    private float pointWidth;


    // Use this for initialization
    void Start()
    {
        pointWidth = thePoints.GetComponent<BoxCollider2D>().size.y;

    }

    // Update is called once per frame
    void Update()
    {

        int randomXPos = RandomNumber(-6, 7);

        if (transform.position.y < generationPoint.position.y)
        {

            //Change position on x axis (Random number)
            transform.position = new Vector2(randomXPos,
                transform.position.y + pointWidth + distanceBetween);

            Instantiate(thePoints, transform.position, transform.rotation);

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
