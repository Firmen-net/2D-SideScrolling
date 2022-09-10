using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    private Animator anim;
    private bool grounded;
    public MenuManager MenuManager;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // MenuManager = GetComponent<MenuManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip Sprite
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //Set Animation
        anim.SetBool("isRunning", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Finish")
        {
            MenuManager.finishedPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}