using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] public float rspeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool isCaught = false;
    public EnemyFOV script1;
    public EnemyFOV script2;
    public EnemyFOV script3;
    public EnemyFOV script4;
    public EnemyFOV script5;
    void Start()
    {
        script1.caught = false;
        script2.caught = false;
        script3.caught = false;
        script4.caught = false;
        script5.caught = false;
        rb = GetComponent<Rigidbody2D>();
        
    }
    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        if(script1.caught == true || script2.caught == true || script3.caught == true || script4.caught == true || script5.caught == true)
        {
            isCaught = true;
        }

    }
    void FixedUpdate()
    {
        //sets movement speed accoring to seconds instead of frames
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        //rotates player to correct direction if player is moving
        if(movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rspeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //catches player if touches beam
        if (collision.CompareTag("beam") || collision.CompareTag("beam2"))
        {
            isCaught = true;
        }
    }
}
