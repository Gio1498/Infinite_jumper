using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    float jumpValue = 200;
    Vector2 jumpForce;

    GameObject player;

    private void Start()
    {
        jumpForce = new Vector2(0, jumpValue);
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& player.GetComponent<PlayerMovement_Prova>().isGrounded*/)
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (Vector2.Angle(collision.contacts[i].normal, Vector2.down) <= 30)
                {

                    collision.rigidbody.AddForce(jumpForce);
                }
            }
        }

    }



}
