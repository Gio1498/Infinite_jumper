using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObj());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Speed);
    }

    private IEnumerator DestroyObj()
    {        
        yield return new WaitForSecondsRealtime(8);        
        Destroy(gameObject);
    }
}
