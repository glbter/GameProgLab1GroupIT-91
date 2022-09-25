using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCarPlayerScript : MonoBehaviour
{
    public float speed = 80f;
    public float jumpForce = 5.0f;

    public float gravityScale = 1;
    public float fallingGravityScale = 1;

    public float maxSpeed = 10;
    public float maxTracableDistance = 5;

    private bool isGrounded;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update()
    {
        Move();
        AddGravity();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("pressed space");
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float changeX = moveX * speed * Time.deltaTime;

        transform.Translate(changeX * Vector2.right);
    }

    private void AddGravity()
    {
        if (rb.velocity.y >= 0)
        {
           rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exited");
        if (rb.velocity.y != 0)
        {
            isGrounded = false;
        }
    }
}
