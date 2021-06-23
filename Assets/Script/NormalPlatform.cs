using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    float jumpValue = 350;
    Vector2 jumpForce;
    private bool playerCollision;

    private void Start()
    {
        jumpForce = new Vector2(0, jumpValue);
        playerCollision = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerCollision)
        {
            playerCollision = true;
            collision.rigidbody.AddForce(jumpForce);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerCollision = false;
        }
    }
    
}
