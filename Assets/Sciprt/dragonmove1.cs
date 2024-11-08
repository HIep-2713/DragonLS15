using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Dragonmove1 : MonoBehaviour

{
    public float move;
    public Animator ani;
    public float speed = 10f;
    public Rigidbody2D rd;
    private bool isFacingRight = true;
    private bool grounded;
    public float Jumphigh;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
            Debug.Log("dragon left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1;
            Debug.Log("dragon move right");
        }
        else
        {
            move = 0;
            Debug.Log("Dragon idie");
        }
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);        
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(move < 0 && isFacingRight)
        {
            Flip();
        }
        ani.SetFloat("walk1", Mathf.Abs(move));
        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();

    }
    private void Jump()
    {
        rd.velocity = new Vector2(rd.velocity.x, speed);
        ani.SetTrigger("Jump");
        grounded = false;
        rd.AddForce((Vector2.up) * Jumphigh);

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,transform.localScale.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
