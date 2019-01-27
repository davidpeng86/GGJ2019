using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    Image buttonImage;
    bool gameStart;
    public AudioSource buttom;
    public AudioClip buttomclip;
    public GameObject sceneChange;

    [SerializeField]
    private Sprite lightsOff;

    [SerializeField]
    private Sprite lightsOn;


    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buttom.PlayOneShot(buttomclip);
            buttonImage.sprite = lightsOn;
            gameStart = true;
        }
        if(gameStart == true){
            sceneChange.SetActive(true);
        }
    }

}
