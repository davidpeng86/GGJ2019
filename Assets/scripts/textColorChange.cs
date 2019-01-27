using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textColorChange : MonoBehaviour
{
    Text text;
    Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        newColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			newColor = new Color(1 - text.color.r,1 - text.color.g,1 - text.color.b);
        }
        text.color = newColor;
    }
}
