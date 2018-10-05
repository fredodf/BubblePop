using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.gameObject.tag);
        if(collider.gameObject.tag=="Ball")
        {
            FindObjectOfType<GameStatus>().LoseLife(collider.gameObject);
        }
        if (collider.gameObject.tag == "Pill")
        {
            Destroy(collider.gameObject);
        }


    }


}
