using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public int direction = 1;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(speed * direction * Time.deltaTime, rb.velocity.y);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            jump();
        }
    }

    void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RightEnd"))
        {
            if(direction == 1){
                transform.position = new Vector2(-collision.transform.position.x, transform.position.y);

            }
        }
        else if (collision.CompareTag("LeftEnd"))
        {
            if (direction == -1)
            {
                transform.position = new Vector2(-collision.transform.position.x, transform.position.y);

            }
        }
    }
}
