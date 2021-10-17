using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour
{
    public AudioSource whipSound,gameoverSound;

    public int GameState = 0;   //0 not started , 1 to be started , 2 started ,3 to be finished, 4 game is over
    public GameObject PanelGameOver, PanelGameStarted , RestartButton;


    //MANAGE UI
    public Text ScoreText, LivesNo ,HighScoreTextPanel , ScorePanel;
    public int collisionStatus = 0;
    public int life = 3;

    public static ManageScore instance;

    public float speed=30f;
    public int score , HighestScore;
    float timePassedInGame;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        LivesNo.text = 3.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == 1)
        {
            // to be started
            InvokeRepeating("scoreIncrease", .5f, .2f);
            GameState = 2;
        }
        if (GameState == 3)
        {
            
            // to be finished
            CancelInvoke("scoreIncrease");
            GameState = 4;
        }
        timePassedInGame += Time.deltaTime;
        
        if(life<3&& GameState==2)
        {
            if (score > 30)
            {
                // lets make it interesting
                if (score > 100)
                {
                    int x = 100;
                    while (score/x  > 0)
                    {
                        x = x * 10;
                        
                    }
                    score = score%(x/10) ;
                    life += 1;
                    LivesNo.text = life.ToString();
                }
                else
                {
                    score -= 30;
                    life += 1;
                    LivesNo.text = life.ToString();
                }
                
                
            }
        }

        if (collisionStatus == 1&&GameState==2)
        {
            
            Debug.Log("enter here");
            collisionStatus = 0;
            if (life > 1)
            {
                life -= 1;
                LivesNo.text = life.ToString();
            }
            else
            {
                // add sound
                whipSound.Play();
                gameoverSound.Play();
                //gameover
                GameState = 3; 
                life = 0; ;
                LivesNo.text = life.ToString();
                PanelGameOver.gameObject.SetActive(false);
                // set  score
                ScorePanel.text = score.ToString();
                // set HighScore
                if (PlayerPrefs.HasKey("HS"))
                {
                    int tempHighScore = PlayerPrefs.GetInt("HS");
                    if (tempHighScore > score)
                    {
                        HighestScore = tempHighScore;
                    }
                    else
                    {
                        HighestScore = score;
                        PlayerPrefs.SetInt("HS", HighestScore); // new High score
                    }
                }
                else
                {
                    HighestScore = score;
                    PlayerPrefs.SetInt("HS", HighestScore); // new High score
                }
                HighScoreTextPanel.text = HighestScore.ToString();   // this will set the highest score

                PanelGameOver.gameObject.SetActive(true);
                Debug.Log("game over Panel set active");
                RestartButton.SetActive(true);
            }
        }

        if(collisionStatus ==2 && GameState == 2)
        {
            collisionStatus = 0;

            score += 30;
        }

    }

    private void scoreIncrease()
    {
        score += 1;
        ScoreText.text = score.ToString();  // displays score
    }

    public void gameStarted()
    {
        GameState = 1;
        PanelGameStarted.GetComponent<Animator>().Play("GameStarted");
        whipSound.Play();
    }

    public void gameRestart()
    {
        PanelGameOver.GetComponent<Animator>().Play("GameRestart");
        whipSound.Play();
        //add music
        GameState = 2;
        RestartButton.SetActive(false);

        life = 3;
        LivesNo.text = life.ToString();
        score = 0;
        ScoreText.text = score.ToString();

        // make speed also 0 so that spawning is slow in restarting 
       speed = 30f;

        InvokeRepeating("scoreIncrease", .5f, .2f);
        
    }
}
