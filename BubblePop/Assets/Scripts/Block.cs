using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    // [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;
    //[SerializeField] GameObject pillMould;
    public GameObject pill;

    Level level; //cached reference
    Sprite sprite;
    


    //state variables
    [SerializeField] int timesHit; //serialize for debug

    private void Start()
    {
        if (tag == "Breakable")
        {
            pill = Resources.Load("Pill") as GameObject;
            level = FindObjectOfType<Level>();
            level.addBlock();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length; 
        if (timesHit >= maxHits)
        {
            destroyBlock();
            pillOpportunity();
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void pillOpportunity()
    {
        if (Random.Range(1,7)==3)
        {
            GameObject pilln = Instantiate(pill, transform.position,transform.rotation) as GameObject;
        }
    }

    private void showNextHitSprite()
    {
        if (hitSprites[timesHit] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
        }
        else
        {
            Debug.LogError("Block sprite missing from array " + gameObject.name);
        }
    }

    private void destroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0f);
        level.brokenBlock();
        FindObjectOfType<GameStatus>().addScore();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

 

}
