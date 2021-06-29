using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Prova : MonoBehaviour
{
    public float Speed;
    public Transform FeetPos;
    public float CheckRadius;
    public LayerMask Ground;
    //public bool isGrounded;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();

        //isGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, Ground);        
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * Speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    
}
