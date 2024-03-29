﻿using System.Collections;
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
    public Points points;    
    
    private void Awake()
    {
        points = transform.parent.GetComponent<Points>();
        GameEventMng.EndBossFightEvent += EndFight;
    }

    // Start is called before the first frame update
    void Start()
    {       
        dist = 6;
        initialY = -3.6f;
        maxDistYFromPlayer = 2;
        minX = -1.94f;
        maxX = 1.94f;
        newSpawn = initialY + dist;

        for (int i = 0; i < 10; i++)
        {
            if(i == 0)
            {
                int randomDir = Random.Range(0, 2);

                if(randomDir == 0)
                    randomX = Random.Range(minX, -1.16f);
                else
                    randomX = Random.Range(1.52f, maxX);
            }
            else
                randomX = Random.Range(minX, maxX);

            randomY = Random.Range(initialY, initialY + maxDistYFromPlayer);
            randomPlatform = Random.Range(0, Platforms.Length);
            
            GameObject go = Platforms[randomPlatform];
            Instantiate(go, new Vector3(randomX, randomY, 0), Quaternion.identity, PlatformsContainer);
            
            initialY = randomY + 0.6f;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= newSpawn)
        {
            for (int i = 0; i < 6; i++)
            {
                randomX = Random.Range(minX, maxX);
                randomY = Random.Range(initialY, initialY + maxDistYFromPlayer);
                randomPlatform = Random.Range(0, Platforms.Length);

                GameObject go = Platforms[randomPlatform];
                Instantiate(go, new Vector3(randomX, randomY, 0), Quaternion.identity, PlatformsContainer);

                initialY = randomY + 0.6f;
            }

            newSpawn += dist;
        }

        if(PlatformsContainer.childCount > 50)
        {
            for (int i = 0; i < 15; i++)
            {
                Destroy(PlatformsContainer.GetChild(i).gameObject);
            }
        }

        if (points.startedBossFight)
        {
            for (int i = PlatformsContainer.childCount - 10; i < PlatformsContainer.childCount; i++)
            {
                if (PlatformsContainer.GetChild(i).gameObject.transform.position.y > points.platformY)
                    Destroy(PlatformsContainer.GetChild(i).gameObject);
            }

            if (transform.position.y > points.platformY + 0.65f)
            {
                for (int i = 0; i < PlatformsContainer.childCount; i++)
                {                    
                    Destroy(PlatformsContainer.GetChild(i).gameObject);
                }

                points.startedBossFight = false;
            }
        }        
    }

    void EndFight()
    {
        newSpawn = transform.position.y - 0.1f;
        initialY = newSpawn + 0.3f; 
    }
}
