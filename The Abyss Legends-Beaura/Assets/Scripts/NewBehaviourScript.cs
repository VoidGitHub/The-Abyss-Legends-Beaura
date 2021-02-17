using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocity = 5; //determines the player velocity
  public float jumpForce = 5; //determines the force aplicated when "Z" is pressed
    Rigidbody2D rb;
  bool canJump; //the declaration of the bool canJump
       void Start() {
        rb = GetComponent<Rigidbody2D>();
      }

    void Update()
    {
        if(Input.GetKey("left"))
        {

          gameObject.transform.Translate(-velocity * Time.deltaTime, 0, 0); //if the left key is pressed the player will move left
        }

        if(Input.GetKey("right"))
        {

          gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0); //if the right key is pressed the player will move right
        }

        if(Input.GetKeyDown("up") && canJump == true) //if you press UP and canJump is true the jump function is called and canJump is returned to false
        {
           Jump();
          canJump = false;
            
        }
    }

    void Jump(){

     rb.AddForce( new Vector2(0, jumpForce), ForceMode2D.Impulse); // the only purpose of this function is
    }                                                                    //to make the character jump


    public void Collision2D(Collider2D other)
    {
      if (other.gameObject.tag == "jumpable") {    // if you are over a collider tagged "jumpable" canJump will be true

      canJump = true;
    }

    }
}
