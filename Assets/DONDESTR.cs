using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONDESTR : MonoBehaviour
{
    public static DONDESTR instance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        gameObject.GetComponent<AudioSource>().time = 4 ;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
