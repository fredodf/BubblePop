using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 3f;
    [SerializeField] float yPush = 9f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.4f;

    bool hasStarted ;
    //state
    Vector2 paddleToBallVector;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    public Ball()
    {
         hasStarted = false;

    }

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
      
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockballToPaddle();
        }
        LaunchOnMouseClick();

    }

    private void LaunchOnMouseClick()
    {
        if (hasStarted != true)
       {
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                myRigidBody2D.velocity = new Vector2(xPush, yPush);
            }
        }
    }

    private void LockballToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = (paddlePos + paddleToBallVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }

    }

    public void DestroyBall()
    {
        Destroy(this);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name=="Lose Collider")
        {
            Destroy(gameObject, 1f);
        }
    } 
    */
}
