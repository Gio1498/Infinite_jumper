using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject Platform;
    public bool startedBossFight;
    public float platformY;

    int points, bossPoints, pointsToDo;
    float y, newY;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        startedBossFight = false;
        points = 0;
        bossPoints = 300;
        pointsToDo = 300;
        go = Platform;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        newY = transform.position.y;

        if (newY > y)
        {
            y = newY;
            points++;
            Text.text = points.ToString();
        }

        if (points >= bossPoints)
        {
            platformY = transform.position.y + 8;
            Instantiate(go, new Vector3(0, platformY), Quaternion.identity);

            startedBossFight = true;

            bossPoints += pointsToDo;
        }
    }
}
