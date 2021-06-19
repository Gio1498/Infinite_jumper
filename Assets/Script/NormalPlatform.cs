using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
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
            Debug.Log("Collision");
            PlayerRB.AddForce(jumpForce);
        }
    }
}
