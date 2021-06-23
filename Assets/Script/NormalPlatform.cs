using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    float jumpValue = 350;
    Vector2 jumpForce;

    private void Start()
    {
        jumpForce = new Vector2(0, jumpValue);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.rigidbody.AddForce(jumpForce);
        }
    }
}
