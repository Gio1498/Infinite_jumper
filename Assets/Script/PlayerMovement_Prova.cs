using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Prova : MonoBehaviour
{
    public float Speed; 
    public GameObject FireBall;
    
    Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();         
        
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            GameObject go = FireBall;
            Instantiate(go, new Vector3(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);             
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * Speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }    
}
