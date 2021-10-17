using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsIncrease : MonoBehaviour
{
    public AudioSource GainPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger is being entered");

        if (collision.gameObject.tag == "Enemy")
        {
            //decrease lives
            ManageScore.instance.collisionStatus = 1;

            GainPoints.Play();
        }
    }
}
