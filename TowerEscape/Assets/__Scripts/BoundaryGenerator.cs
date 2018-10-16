using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MonoBehaviour {


    public GameObject theBoundary;
    public Transform generationPoint;
    public float distanceBetween;
    private float boundaryWidth;

	// Use this for initialization
	void Start () {
        boundaryWidth = theBoundary.GetComponent<BoxCollider2D>().size.y;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y + boundaryWidth + distanceBetween);

            Instantiate(theBoundary, transform.position, transform.rotation);
        }
	}
}
