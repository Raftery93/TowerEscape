using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    //Variables & handles to game objects
    public GameObject theBackground;
    public Transform generationPoint;
    public float distanceBetween;
    private float BackgroundWidth;
    GameObject clones;
    
    void Start()
    {
        //Set/get background width
        BackgroundWidth = theBackground.GetComponent<BoxCollider2D>().size.y;
    }
    
    void Update()
    {
        //Generate background
        if (transform.position.y < generationPoint.position.y)
        {
            //Get background dimensions
            transform.position = new Vector3(transform.position.x,
                transform.position.y + BackgroundWidth + distanceBetween, 1);

            //Instantiate background into game
            clones = Instantiate(theBackground, transform.position, transform.rotation);
        }

        //Destroy background after 30 sec
        Destroy(clones, 30);
    }
}
