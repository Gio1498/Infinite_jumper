using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform DestinationPortal; //Se lo script viene messo nel portale destro il destination portal sarà il portale sinistro e viceversa.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.name == "Right Portal")
            {
                collision.gameObject.transform.position = new Vector2(DestinationPortal.position.x + 0.5f, DestinationPortal.position.y);
            }
            if (this.gameObject.name == "Left Portal")
            {
                collision.gameObject.transform.position = new Vector2(DestinationPortal.position.x - 0.5f, DestinationPortal.position.y);
            }
        }
    }
}
