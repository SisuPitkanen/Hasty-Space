using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Outside_Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private GameObject target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jettpack"))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
