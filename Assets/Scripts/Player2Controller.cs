using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public float highJump;

    bool facingRight;
    bool grounded;



    Rigidbody2D mybody;
    Animator myanimator;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();

        facingRight = true;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        myanimator.SetFloat("Speed", Mathf.Abs(move));

        mybody.velocity = new Vector2(move * speed, mybody.velocity.y);
        
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space)){
            Debug.Log(message: "jump");
            if (grounded)
            {
                grounded = false;
                mybody.velocity = new Vector2(mybody.velocity.x, highJump);
            }
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
