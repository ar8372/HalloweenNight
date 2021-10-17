using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public AudioSource LoosePoints, GainPoints;
    public GameObject particle , verticalBar;
    private void Awake()
    {
       // gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
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

        if (collision.gameObject.tag == "Enemy" && ManageScore.instance.GameState == 2)
        {
            verticalBar.gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            Invoke("ChangeColorBack", .1f);
            Invoke("ChangeColorToWhite", .2f);
            Invoke("ChangeColorBack", .3f);
            Invoke("ChangeColorToWhite", .4f);
            Invoke("ChangeColorBack", .5f);
            //decrease lives
            ManageScore.instance.collisionStatus =1;

            LoosePoints.Play();
            LoosePoints.volume = 5;
        }
        if (collision.gameObject.tag == "Points" && ManageScore.instance.GameState==2)
        {
            // show particle effect
            GameObject tempParticle = Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            tempParticle.transform.Rotate(90, 0, 0);
            Destroy(tempParticle, 1f);

            ManageScore.instance.collisionStatus = 2;
            Destroy(collision.gameObject);
            GainPoints.Play();


        }
    }

    
    private void ChangeColorBack()
    {
        string htmlValue = "#DD3131";
        

        Color newCol;

        if (ColorUtility.TryParseHtmlString(htmlValue, out newCol))
        {
            gameObject.GetComponent<Renderer>().material.color = newCol;
            verticalBar.gameObject.GetComponent<Renderer>().material.color = newCol;
        }
        ///gameObject.GetComponent<Renderer>().material.color = #DD3131;
    }
    private void ChangeColorToWhite()
    {
        verticalBar.gameObject.GetComponent<Renderer>().material.color = Color.white;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
