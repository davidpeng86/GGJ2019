using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostTimer : MonoBehaviour
{   
    public GameObject ghost;
    static bool b_isDown;
    int nextDown;

    int rand_min;
    int rand_max;

    int rand_sec;

    float f_ghostTimer;

    // Start is called before the first frame update
    void Start()
    {
        rand_sec = Random.Range(3,5);
        nextDown = rand_sec;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextDown){
            Debug.Log("Ghost Down");
            b_isDown = true;
            rand_min = Random.Range(1,3);
            rand_max = Random.Range(5,8);
            rand_sec = Random.Range(rand_min,rand_max);
            nextDown = (int)(Time.time + rand_sec);
            
        }

        if(b_isDown == true){
            ghost.SetActive(true);
            f_ghostTimer = Time.time;
            b_isDown = false;
        }

        if(Time.time - f_ghostTimer >= 1f){
            ghost.SetActive(false);
        }
    }


}
