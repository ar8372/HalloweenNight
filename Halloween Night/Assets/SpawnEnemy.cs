using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyList;
    GameObject[] enemy = new GameObject[20];

    int LastSpawwnedPos = 0;   // 0 for not spawned , 1 for spawned in right  , 2 for spawned in left
    int SecondLastSpawwnedPos = 0;   // 0 for not spawned , 1 for spawned in right  , 2 for spawned in left

    float TimeCalculate = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<20; i++)
        {
            enemy[i] = enemyList.transform.GetChild(i).gameObject;  // access all the children gameobjects of the parent gameobject
        }

    }

    // Update is called once per frame
    void Update()
    {
        TimeCalculate += Time.deltaTime;
        Debug.Log(TimeCalculate);

        if (TimeCalculate >= .5f&& (ManageScore.instance.GameState==2))
        {
            SpawnTheEnemy();
            ManageScore.instance.speed += .1f;
        }
    }

    private void SpawnTheEnemy()
    {
        int spawningEnemyNo = Random.Range(0, 20);

        Debug.Log("hello");
        int randomNo = Random.Range(1, 10);
        if (randomNo <= 9)
        {
            // we will spawn the enemy
            if (LastSpawwnedPos == 0)
            {
                // enemy was not spawned
                SecondLastSpawwnedPos = 0;

                int x = Random.Range(1, 3);
                if (x == 1)
                {
                    // spawn enemy at left
                    Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
                    LastSpawwnedPos = 2;
                }
                else
                {
                    // spawn enemy at right
                    Instantiate(enemy[spawningEnemyNo], transform.position, Quaternion.identity);
                    LastSpawwnedPos = 1;
                }
            }
            else if(LastSpawwnedPos == 1)
            {
                // enemy was spawned in right
                SecondLastSpawwnedPos = 1;

                if (SecondLastSpawwnedPos == 1)
                {
                    // two already
                    // enemy was not spawned it is equivalent
                    int x = Random.Range(1, 3);
                    if (x == 1)
                    {
                        // spawn enemy at left
                        Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
                        LastSpawwnedPos = 2;
                    }
                    else
                    {
                        // spawn enemy at right
                        Instantiate(enemy[spawningEnemyNo], transform.position, Quaternion.identity);
                        LastSpawwnedPos = 1;
                    }
                }
                else
                {
                    int x = Random.Range(1, 3);
                    if (x == 1)
                    {
                        // don't spawn
                        //Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
                        LastSpawwnedPos = 0;
                    }
                    else
                    {
                        // spawn enemy at right
                        Instantiate(enemy[spawningEnemyNo], transform.position, Quaternion.identity);
                        LastSpawwnedPos = 1;
                    }
                }
                
            }
            else
            {
                // enemy was spawned in left
                SecondLastSpawwnedPos = 2;

                if (SecondLastSpawwnedPos == 2)
                {
                    // two already
                    // enemy was not spawned
                    int x = Random.Range(1, 3);
                    if (x == 1)
                    {
                        // spawn enemy at left
                        Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
                        LastSpawwnedPos = 2;
                    }
                    else
                    {
                        // spawn enemy at right
                        Instantiate(enemy[spawningEnemyNo], transform.position, Quaternion.identity);
                        LastSpawwnedPos = 1;
                    }

                }
                else
                {
                    int x = Random.Range(1, 3);
                    if (x == 1)
                    {
                        // don't spawn
                        //Instantiate(enemy[spawningEnemyNo], transform.position, Quaternion.identity);
                        LastSpawwnedPos = 0;

                    }
                    else
                    {
                        // spawn enemy at left
                        Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
                        LastSpawwnedPos = 2;
                    }
                }

                
            }
        }
        else
        {
            // we will not spawn the enemy
            LastSpawwnedPos = 0;
        }



        // spawn the enemy
        //Instantiate(enemy1, transform.position, Quaternion.identity);
        //Instantiate(enemy[spawningEnemyNo], transform.position - new Vector3(3f, 0f, 0), Quaternion.identity);
        //reset the time
        TimeCalculate = 0;
    }
}
