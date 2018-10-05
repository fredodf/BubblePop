using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour {

    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int score = 0;
    [SerializeField] int pointsPerBlock = 77;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool autoPlayEnabled;
    [SerializeField] int lives = 3;
    [SerializeField] Ball ball;
    int highScore;
    

     //[SerializeField] GameObject ballMould;


    private void Awake()
    {
        int  gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void resetSession()
    {
        Destroy(gameObject);
    }
    
        
        // Use this for initialization
    void Start () {
        livesText.text = lives.ToString();

    }

    // Update is called once per frame

    void Update () {

        Time.timeScale = gameSpeed;
        scoreText.text = score.ToString();
	}

    public void addScore()
    {
        score += pointsPerBlock;

    }

    public void addPillScore()
    {
        score += 100;

    }

    public bool IsAutoplayEnabled()
    {
        return autoPlayEnabled;
    }

    public void LoseLife(GameObject x)
    {
        lives--;
        livesText.text = lives.ToString();

        if (lives<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Vector3 ballPos = new Vector3(FindObjectOfType<Paddle>().transform.position.x,0.84f);
            
            if (x)
            {

                //Debug.Log(ball.ToString());
                // Destroy(x);
              
                GameObject balln =  Instantiate(ball.gameObject, ballPos, rotation: transform.rotation) as GameObject;
                
                
                

            }
        }


    }

}
