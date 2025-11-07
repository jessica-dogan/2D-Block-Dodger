using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed; //how fast the player will move
 
    Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {// gives access to the rigid body component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {//when user taps the scrren or press a button move player left and right
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;
            touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        //move player to left if user press left
            if(touchPos.x < 0)
            {
                // transform.position += Vector3.left * speed * Time.deltaTime; 
                rb.AddForce(Vector2.left * speed);

            }
            else //else move right if user press right
            {
                // transform.position += Vector3.right * speed * Time.deltaTime;
                rb.AddForce(Vector2.right * speed );
            }


        }
        else //when user is not pressing a button set to 0
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    //check for wall boundaries
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
        }
    }


}
