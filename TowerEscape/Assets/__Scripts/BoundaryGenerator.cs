using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MonoBehaviour {

    //Variables & handles to game objects
    public GameObject theBoundary;
    public Transform generationPoint;
    public float distanceBetween;
    private float boundaryWidth;
    GameObject clones;
    
	void Start () {
        //Set/get boundary width
        boundaryWidth = theBoundary.GetComponent<BoxCollider2D>().size.y;
	}
	
	void Update () {
		
        //Generate boundary
        if(transform.position.y < generationPoint.position.y)
        {
            //Get boundary dimensions
            transform.position = new Vector2(transform.position.x,
                transform.position.y + boundaryWidth + distanceBetween);

            //Instantiate boundaries into game
           clones = Instantiate(theBoundary, transform.position, transform.rotation);
        }

        //Destroy boundaries after 30 sec
        Destroy(clones, 30);
    }
}
