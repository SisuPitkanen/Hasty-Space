using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Point_Movement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float radius;
    public float angle;

    void Start()
    {
        speed = 1f;
        radius = 10f;
        angle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + Mathf.Sin (angle) * radius;

        transform.position = new Vector2(x, y);

        angle += speed * Time.deltaTime;
    }
}
