using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public GameObject theBackground;
    public Transform generationPoint;
    public float distanceBetween;
    private float BackgroundWidth;

    // Use this for initialization
    void Start()
    {
        BackgroundWidth = theBackground.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + BackgroundWidth + distanceBetween, 1);

            Instantiate(theBackground, transform.position, transform.rotation);
        }
    }
}
