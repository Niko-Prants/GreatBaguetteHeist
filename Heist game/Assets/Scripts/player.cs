using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool isCaught = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
    }
    void FixedUpdate()
    {
        //sets movement speed accoring to seconds instead of frames
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //catches player if touches beam
        if (collision.CompareTag("beam"))
        {
            isCaught = true;
        }
    }
}
