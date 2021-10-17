using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerHorizontal;
    public AudioSource WhipSound;

    // define stage of Horzontal bar
    int StateOfPlayer = 0;   //0 for right and 1 for left
    

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipButtonPressed()
    {
        
        WhipSound.Play();
        

        if (StateOfPlayer == 0)
        {
            //Player is in right
            PlayerHorizontal.transform.position = new Vector2(-1.234f, -1.32f);
            StateOfPlayer = 1;
        }
        else
        {
            //Player is in left
            PlayerHorizontal.transform.position = new Vector2(1.234f, -1.32f);
            StateOfPlayer = 0;
        }
        
    }
}
