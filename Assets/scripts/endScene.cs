using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScene : MonoBehaviour
{
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(828, 1792, true, 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fadeOut.SetActive(true);
        }
    }


}
