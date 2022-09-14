using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    bool isJumping;

    public float speed;
    public float jumpForce;
    public float jump;
    public float maxJump;
    Vector2 jumpDirection = new Vector2(0, 2);

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jump();
    } 
    
    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (speed != 0)
        {
            transform.Translate(transform.right * inputX * speed * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (Input.GetButton("Jump") && jump < maxJump)
        {
            rb2d.velocity = jumpDirection * jumpForce;
            jump++;
        }
    }

    void isGrounded()
    {
        jump = 0;
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limits"))
        {
            GameManager.eventIsDead?.Invoke();
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            GameManager.eventWinner?.Invoke();
        }

        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded();
        }
    }
}
