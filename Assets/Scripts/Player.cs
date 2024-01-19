using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidbody;
    private float moveX;
    private float moveY;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Animal>().Damage();
    }
}
