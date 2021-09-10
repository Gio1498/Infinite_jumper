using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    float jumpValue = 200;
    Vector2 jumpForce;
    bool endFight, canJump;
    GameObject player;

    private void Awake()
    {
        GameEventMng.EndBossFightEvent += EndFight;
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = new Vector2(0, jumpValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canJump)
        {
            if (collision.gameObject.CompareTag("Player"))
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(endFight)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (Vector2.Angle(collision.contacts[i].normal, Vector2.down) <= 30)
                    {

                        collision.rigidbody.AddForce(jumpForce);
                    }
                }
            }

            endFight = false;
            canJump = true;

            StartCoroutine(DestroyThis());
        }
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSecondsRealtime(10);
        Destroy(gameObject);
    }

    void EndFight()
    {
        endFight = true;
    }
}
