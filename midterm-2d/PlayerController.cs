using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject gameDirector;
    private Rigidbody2D body;
    private Animator animator;
    private float speed = 4;
    private bool grounded;
    private bool isHit = false;

    void Start()
    {
        this.gameDirector = GameObject.Find("GameDirector");
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        SetAnimateParam();
    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // returns -1~1 when press l,r key
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded) // jump
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * 2);
        animator.SetTrigger("jump");
        gameObject.GetComponent<AudioSource>().Play();
        grounded = false;
    }

    private void SetAnimateParam()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Trap")
        {
            transform.localScale = Vector3.one;
            gameObject.transform.position=new Vector2(-6.4f, 0f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            this.gameDirector.GetComponent<GameDirector>().EndGame();
            AudioSource hurtSound = GameObject.Find("goal").GetComponent<AudioSource>();
        }

        if (other.gameObject.tag == "Ball"&&!isHit)
        {
            this.isHit = true;
            this.gameDirector.GetComponent<GameDirector>().decreaseHp();
            AudioSource hurtSound = GameObject.Find("BallGenerator").GetComponent<AudioSource>();
            hurtSound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.isHit = false;
    }
}
