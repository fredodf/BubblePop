using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlocks=0;

	public void brokenBlock()
    {
        breakableBlocks--;
       
        if (breakableBlocks==0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
    
    public void addBlock()
    {
        breakableBlocks++;
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	

}
