using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float dist;
    float initialY;
    float maxDistYFromPlayer;
    float minX;
    float maxX;
    float newSpawn;

    float randomX, randomY;
    int randomPlatform;

    public Transform PlatformsContainer;
    public GameObject[] Platforms;

    // Start is called before the first frame update
    void Start()
    {
        dist = 5.7f;
        initialY = -3.6f;
        maxDistYFromPlayer = 2;
        minX = -2.76f;
        maxX = 2.76f;
        newSpawn = initialY + dist;

        for (int i = 0; i < 5; i++)
        {
            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(initialY, initialY + maxDistYFromPlayer);
            randomPlatform = Random.Range(0, Platforms.Length);
            
            GameObject go = Platforms[randomPlatform];
            Instantiate(go, new Vector3(randomX, randomY, 0), Quaternion.identity, PlatformsContainer);
            
            initialY = randomY + 0.3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= newSpawn)
        {
            for (int i = 0; i < 3; i++)
            {
                randomX = Random.Range(minX, maxX);
                randomY = Random.Range(initialY, initialY + maxDistYFromPlayer);
                randomPlatform = Random.Range(0, Platforms.Length);

                GameObject go = Platforms[randomPlatform];
                Instantiate(go, new Vector3(randomX, randomY, 0), Quaternion.identity, PlatformsContainer);

                initialY = randomY + 0.5f;
            }

            newSpawn += dist;
        }
    }
}
