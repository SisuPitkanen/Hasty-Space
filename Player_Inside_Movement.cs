using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inside_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public int jump_amount;
    public int jump_power;

    public float speed;
    private float Move;

    public GameObject Pointer;
    public GameObject Jump_Point;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Player_Outside_Movement>().enabled = false;
        Pointer.SetActive(false);
        Jump_Point.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        jump_amount = 1;
        jump_power = 250;
        speed = 5;
        rb.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && jump_amount > 0)
        {
            jump_amount -= 1;
            rb.AddForce(new Vector2(rb.velocity.x, jump_power));
        }

        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Ground"))
       {
            jump_amount = 1;
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Space"))
        {
            GetComponent<Player_Inside_Movement>().enabled = false;
            GetComponent<Player_Outside_Movement>().enabled = true;
            Pointer.SetActive(true);
            Jump_Point.SetActive(true);
            rb.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Space"))
        {
            GetComponent<Player_Inside_Movement>().enabled = true;
            GetComponent<Player_Outside_Movement>().enabled = false;
            Pointer.SetActive(false);
            Jump_Point.SetActive(false);
            rb.gravityScale = 1;
        }
    }
}