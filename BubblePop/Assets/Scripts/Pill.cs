using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour {

    /*Pill Types
    1 makes paddle larger
    2 makes paddle smaller
    3 one life 


    */

    int pillType;

	// Use this for initialization
	void Start ()
    {
        Vector2 pillGravity = new Vector2(0f, -4f);
        GetComponent<Rigidbody2D>().velocity = pillGravity;
        pillType = Random.Range(1, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  

    public int getPillType()
    {

        return pillType;
    }
}
