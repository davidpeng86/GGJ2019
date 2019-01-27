using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headdamage : MonoBehaviour
{
    GameManager gamemanager;
    public int headstate = 0;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        headstateInScene();
    }

    public void headstateInScene()
    {
        gamemanager.HeadState = headstate;
    }
}
