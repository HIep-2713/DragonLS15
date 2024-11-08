using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Dragonmove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator ani;
    private bool grounded;
    public float Jumphigh;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Dragon move left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Dragon move right");
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3 (-1, 1, 1);
         if( Input.GetKey(KeyCode.W) && grounded)
          Jump();
        ani.SetBool("run", horizontalInput != 0);
        ani.SetBool("grounded",grounded);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        ani.SetTrigger("Jump");
        grounded = false;
        body.AddForce((Vector2.up) * Jumphigh);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }

}

