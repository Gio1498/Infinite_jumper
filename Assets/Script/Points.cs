using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI Text;
    int points;
    float y, newY;

    // Start is called before the first frame update
    void Start()
    {
        //Text = Text.GetComponent<Text>();
        points = 0;
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
    }
}
