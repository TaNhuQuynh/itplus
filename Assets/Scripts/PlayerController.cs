using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed = 5f;
    public float highjump = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "hello");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnMove();
        OnJump();
    }

    void OnMove()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1);
            rigidbody2D.AddForce(new Vector2(-1 * speed, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1);
            rigidbody2D.AddForce(new Vector2(1 * speed, 0));
        }

        //float Direction = Input.GetAxisRaw("Horozonal");
        //Vector2 moveVector = new Vector2(Direction * speed, 0);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector);
    }

    void OnJump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.AddForce(new Vector2(0, highjump));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
