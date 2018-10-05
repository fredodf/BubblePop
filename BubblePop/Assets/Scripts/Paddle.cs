using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthinUnits = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;

    GameStatus gameConfig;
    Ball currBall;

    // Use this for initialization
    void Start () {
        gameConfig = FindObjectOfType<GameStatus>();
        currBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); 
        transform.position = paddlePos;
		
	}

    private float GetXPos()
    {
        float XPos;

        if (gameConfig.IsAutoplayEnabled())
        {
            XPos = currBall.transform.position.x;
            return XPos; 

        }
        else
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthinUnits;
            XPos = mousePosInUnits;
            return XPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int pillType;
        if(collision.gameObject.tag == "Pill")
        {
            pillType= FindObjectOfType<Pill>().getPillType();
            FindObjectOfType<GameStatus>().addPillScore();  

            if (pillType != 3)
            {
                switch (pillType)
                {
                    case 1:
                        ScalePaddle(pillType);
                        break;
                    case 2:
                        ScalePaddle(pillType);
                        break;
                    default:
                        break;
                }

            }

        }
    }

    private void ScalePaddle(int type)
    {
        if (type == 1)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1f, 1f);
        }
        if (type==2)
        {
            gameObject.transform.localScale = new Vector3(.7f, 1f, 1f);

        }
    }

}
