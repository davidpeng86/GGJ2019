using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseshow : MonoBehaviour
{

    public Texture mouseTexture;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        Vector3 mousePos = Input.mousePosition;
        Rect rect = new Rect(mousePos.x, Screen.height - mousePos.y, 150, 150);
        GUI.DrawTexture(rect, mouseTexture);
        //Debug.Log(mousePos.ToString());
    }
}
