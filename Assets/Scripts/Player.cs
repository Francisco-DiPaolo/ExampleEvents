using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    } 
    
    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (speed != 0)
        {
            transform.Translate(transform.right * inputX * speed * Time.deltaTime);
        }
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
    }
}
