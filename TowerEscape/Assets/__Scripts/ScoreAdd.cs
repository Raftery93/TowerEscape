using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for adding to the score
public class ScoreAdd : MonoBehaviour {

    public int pointsToAdd;

    void OnTriggerEnter2D (Collider2D other)
    {

        if(other.GetComponent<PlayerBehaviour>() == null)
        {
            return;
        }

        ScoreManager.AddPoints(pointsToAdd);

        Destroy(gameObject);
    }
}
