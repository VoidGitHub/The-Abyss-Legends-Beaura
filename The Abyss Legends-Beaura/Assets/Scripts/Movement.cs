using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D body;

    float horizontal;
    float vertical;
    public float moveLimiter = 0.5f;

    public float runSpeed = 5.0f;
    public float sprintSpeed = 7.0f;
    public int Stamina = 100;
    public float dashSpeed = 30.0f;
    public bool Dashing;
    public float SlowSpeed = 0.5f;
    public Animator animator;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Dash();
    }

    void Update()
    {

        // Gives a value between -1 and 1

        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", runSpeed);

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if (Input.GetButton("Sprint") && Stamina > 0)
        {
            body.velocity = new Vector2(horizontal * sprintSpeed, vertical * sprintSpeed);
            Invoke("Stamina2", 5);
        }
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            Invoke("StaminaRegen", 8);



        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D) && Dashing == true)
        {
            Invoke("DashFalse", 0.25f);
            transform.position = transform.position + new Vector3(0.1f, 0, 0);
            Invoke("Dash", 5);

        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A) && Dashing == true)
        {
            Invoke("DashFalse", 0.25f);
            transform.position = transform.position + new Vector3(-0.1f, 0, 0);
            Invoke("Dash", 5);

        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S) && Dashing == true)
        {
            Invoke("DashFalse", 0.25f);
            transform.position = transform.position + new Vector3(0, -0.1f, 0);
            Invoke("Dash", 5);

        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && Dashing == true)
        {
            Invoke("DashFalse", 0.25f);
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
            Invoke("Dash", 5);

        }



    }
    public void Stamina2()
    {
        Stamina = 0;
    }
    public void StaminaRegen()
    {

        Stamina = 100;

    }
    public void Regen()
    {
        Stamina = 100;
    }
    public void Dash()
    {
        Dashing = true;
    }
    public void DashFalse()
    {
        Dashing = false;
    }




}