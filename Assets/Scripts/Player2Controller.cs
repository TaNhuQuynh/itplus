using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float speed;
    [SerializeField] private float highJump;

    bool facingRight;
    bool grounded;




    [SerializeField] Rigidbody2D mybody;
    [SerializeField] Animator myanimator;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();

        facingRight = true;
    }

    void FixedUpdate()
    {
        Debug.Log(message: "run");
        float move = Input.GetAxis("Horizontal");

        myanimator.SetFloat("Speed", Mathf.Abs(move));

        mybody.velocity = new Vector2(move * speed, mybody.velocity.y);

        void flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(message: "jump");
            if (grounded)
            {
                grounded = false;
                mybody.velocity = new Vector2(mybody.velocity.x, highJump);
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D other) //va cham
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void die()
    {
        myanimator.SetBool("die", true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="DeadTouch")
        {
            die();
        }
    }





    }
