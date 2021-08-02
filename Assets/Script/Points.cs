using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject Platform;
    public bool bossFight;

    int points, bossPoints;
    float y, newY, platformY;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        bossFight = false;
        points = 0;
        bossPoints = 400;
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
            platformY = transform.position.y - 2;
            Instantiate(go, new Vector3(0, platformY), Quaternion.identity);

            bossFight = true;

            bossPoints += bossPoints;
        }
    }
}
