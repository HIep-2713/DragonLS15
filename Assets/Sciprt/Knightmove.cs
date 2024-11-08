using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Knigthmove : MonoBehaviour

{
    private bool isFacingRight = true;
    public float move;
    public float speed = 10f;
    private Animator ani;
    public Rigidbody2D rd;
    private bool grounded;
    public float Jumphigh;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1;
            Debug.Log("left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1;
            Debug.Log("right");
        }
        else
        {
            move = 0;
            Debug.Log("idie");
        }
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);      
        
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
        ani.SetFloat("walk", Mathf.Abs(move));
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
            Jump();
        //ani.SetBool("run", move!= 0);
        //ani.SetBool("grounded", grounded);
    }
    private void Jump()
    {
        rd.velocity = new Vector2(rd.velocity.x, speed);
        grounded = false;
        rd.AddForce((Vector2.up) * Jumphigh);

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,
 transform.localScale.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }



}

