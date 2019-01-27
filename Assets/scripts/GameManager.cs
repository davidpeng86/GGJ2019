using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region values
    //public Texture mouseTexture;

    public List<Sprite> quilt = new List<Sprite>();
    public List<Sprite> frontEffect = new List<Sprite>();
    public SpriteRenderer quiltSprite;
    public SpriteRenderer effectSprite;

    public int HP = 100;
    public int effectHP01 = 80;
    public int effectHP02 = 60;
    public int effectHP03 = 40;
    public int effectHP04 = 20;

    public int nowSprite = 0;
    public float timer = 3;
    public float quilttime = 3;
    public float quilt01Pos = 0;
    public float quilt02Pos = 0;
    public float quilt03Pos = 0;
    public float quilt04Pos = 0;
    public float quilt05Pos = 0;
    public float quilt06Pos = 0;
    public float quilt07Pos = 0;
    public float quilt08Pos = 0;

    public int HeadState = 9;
    public int NowState = 0;
    public bool isDead = false;

    public int HpChangeValue01 = 1;
    public int HpChangeValue02 = 1;
    public int HpChangeValue03 = 1;
    public int HpChangeValue04 = 1;
    public int HpChangeValue05 = 1;
    public int HpChangeValue06 = 1;
    public int HpChangeValue07 = 1;
    public int HpChangeValue08 = 1;
    //public float quilt09Pos = 0;
    //public float quilt10Pos = 0;
    public float repeatingTimer = 3;
    public float repeatingRate = 1;
    public GameObject lightRoom;
    public GameObject darkRoom;
    public GameObject fadeOut;
    public Image clock;
    public float remaintime = 0;
    public float timecounter = 300;
    public float lightopentime = 1;
    public float lightcpenstatetime = 0.1f;
    public AudioSource HeartBeat;
    public AudioSource Sound;
    public AudioClip OpenLightF;
    public AudioClip OpenLightS;
    public AudioSource MonsterSoundSource;
    public AudioClip MonsterSound;
    public AudioClip HeartBeatClip;
    public AudioClip SpookySoundClip;

    public float closelighttimer = 0;
    public float closelighttime = 5;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(828, 1792, true, 60);
        remaintime = timecounter;
        InvokeRepeating("ChangeHPRate", repeatingTimer, repeatingRate);
        InvokeRepeating("ClockUpdate", 0, 1);
        //InvokeRepeating("ClockUpdate", 0, 1);
        timer = quilttime;
        Cursor.visible = false;
        closelighttimer = closelighttime;
    }

    // Update is called once per frame
    void Update()
    {
        checkLightroom();
        effectShow();
        isDeadCheck();
        //timer -= Time.deltaTime;
        //if (timer <= 0)
        //{
        //    quiltSprite.sprite = quilt[nowSprite];
        //    if (nowSprite < quilt.Count-1) nowSprite++; 
        //    else nowSprite = 0;
        //    timer = quilttime;
        //}
        mouseQuiltMove();
    }

    //private void OnGUI()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    Rect rect = new Rect(mousePos.x, Screen.height - mousePos.y, 150, 150);
    //    GUI.DrawTexture(rect, mouseTexture);
    //    Debug.Log(mousePos.ToString());
    //}

    public void checkLightroom()
    {
        if (lightRoom.activeSelf)
        {
            remaintime -= lightcpenstatetime;
            closelighttimer -= Time.deltaTime;
            if (closelighttimer <= 0)
            {
                closelighttimer = closelighttime;
                Sound.PlayOneShot(OpenLightF);
                if (!lightRoom.activeSelf)
                {
                    remaintime -= lightopentime;
                    lightRoom.SetActive(true);
                }
                else lightRoom.SetActive(false);
                if (darkRoom.activeSelf) darkRoom.SetActive(false);
                else darkRoom.SetActive(true);
            }
        }
    }

    public void isDeadCheck()
    {
        float heartBeatvolume = 1 - ((NowState - HeadState) * 0.05f);

        if (heartBeatvolume <= 0) heartBeatvolume = 0;
        if (NowState > HeadState+1)
        { 
            if (HeadState == 10) return;
            if (HeadState <= 0) return;
            isDead = true;
            //Debug.LogError(NowState + "  " + HeadState);
        }
        else if (HeadState >= 10 || HeadState <= 0)
        {
            if (Sound.clip != null)
            {
                if (Sound.clip.name == "詭異音效")
                {
                    Sound.Stop();
                }
                heartBeatvolume = 1;
            }
        }
        else
        {
            if (!Sound.isPlaying ) Sound.PlayOneShot(SpookySoundClip);
        }
        Debug.Log(heartBeatvolume);
    }

    public void ClockUpdate()
    {
        remaintime --;
        clock.fillAmount = remaintime / timecounter;
        if(remaintime <= 0)
        {
            fadeOut.SetActive(true);
        }
    }

    public void mouseQuiltMove()
    {
        if (Input.mousePosition.y <= quilt01Pos)
        {
            quiltSprite.sprite = quilt[0];
            NowState = 0;
        }
        else if (Input.mousePosition.y > quilt01Pos && Input.mousePosition.y <= quilt02Pos)
        {
            quiltSprite.sprite = quilt[1];
            NowState = 1;
        }
        else if (Input.mousePosition.y > quilt02Pos && Input.mousePosition.y <= quilt03Pos)
        {
            quiltSprite.sprite = quilt[2];
            NowState = 2;
        }
        else if (Input.mousePosition.y > quilt03Pos && Input.mousePosition.y <= quilt04Pos)
        {
            quiltSprite.sprite = quilt[3];
            NowState = 3;
        }
        else if (Input.mousePosition.y > quilt04Pos && Input.mousePosition.y <= quilt05Pos)
        {
            quiltSprite.sprite = quilt[4];
            NowState = 4;
        }
        else if (Input.mousePosition.y > quilt05Pos && Input.mousePosition.y <= quilt06Pos)
        {
            quiltSprite.sprite = quilt[5];
            NowState = 5;
        }
        else if (Input.mousePosition.y > quilt06Pos && Input.mousePosition.y <= quilt07Pos)
        {
            quiltSprite.sprite = quilt[6];
            NowState = 6;
        }
        else if (Input.mousePosition.y > quilt07Pos && Input.mousePosition.y <= quilt08Pos)
        {
            quiltSprite.sprite = quilt[7];
            NowState = 7;
        }
        //else if (Input.mousePosition.y > quilt08Pos && Input.mousePosition.y <= quilt09Pos) quiltSprite.sprite = quilt[8];
    }

    public void effectShow()
    {
        if (HP > effectHP01 && isDead)
        {
            if (Input.anyKey) SceneManager.LoadScene("SampleScene");
            if (effectSprite.sprite != frontEffect[5])
            {
                if(!MonsterSoundSource.isPlaying) MonsterSoundSource.PlayOneShot(MonsterSound);
                if (effectSprite.sprite != frontEffect[5]) effectSprite.sprite = frontEffect[5];
                //Cursor.visible = true;
                return;
            }
        }
        else if (HP <= effectHP01 && isDead)
        {
            if (Input.anyKey) SceneManager.LoadScene("SampleScene");
            if (effectSprite.sprite != frontEffect[6])
            {
                if (!MonsterSoundSource.isPlaying) MonsterSoundSource.PlayOneShot(MonsterSound);
                if (effectSprite.sprite != frontEffect[6]) effectSprite.sprite = frontEffect[6];
                //Cursor.visible = true;
                return;
            }
        }
        else if (HP <= 0 && !isDead)
        {
            if (Input.anyKey) SceneManager.LoadScene("SampleScene");
            if (effectSprite.sprite != frontEffect[4])
            {
                if (!MonsterSoundSource.isPlaying) MonsterSoundSource.PlayOneShot(MonsterSound);
                if (effectSprite.sprite != frontEffect[4]) effectSprite.sprite = frontEffect[4];
                //Cursor.visible = true;
                return;
            }
        }
        if (HP > effectHP01)
        {
            HeartBeat.pitch = 1.0f;
            if (effectSprite.sprite != null)
            {
                effectSprite.sprite = null;
            }
        }
        else if (HP <= effectHP01 && HP > effectHP02)
        {
            HeartBeat.pitch = 1.2f;
            if (effectSprite.sprite != frontEffect[0])
            {
                effectSprite.sprite = frontEffect[0];
            }
        }
        else if (HP <= effectHP02 && HP > effectHP03)
        {
            HeartBeat.pitch = 1.4f;
            if (effectSprite.sprite != frontEffect[1])
            {
                effectSprite.sprite = frontEffect[1];
            }
        }
        else if (HP <= effectHP03 && HP > effectHP04)
        {
            HeartBeat.pitch = 1.6f;
            if (effectSprite.sprite != frontEffect[2])
            {
                effectSprite.sprite = frontEffect[2];
            }
        }
        else if (HP <= effectHP04 && HP > 0)
        {
            HeartBeat.pitch = 1.8f;
            if (effectSprite.sprite != frontEffect[3])
            {
                effectSprite.sprite = frontEffect[3];
            }
        }
        else if (HP <= 0)
        {
            HeartBeat.pitch = 2.0f;
            if (effectSprite.sprite != frontEffect[4])
            {
                effectSprite.sprite = frontEffect[4];
            }
        }
    }

    public void ChangeHPRate()
    {
        if (NowState == 0)
        {
            HP -= HpChangeValue01;
        }
        else if (NowState == 1)
        {
            HP -= HpChangeValue02;
        }
        else if (NowState == 2)
        {
            HP -= HpChangeValue03;
        }
        else if (NowState == 3)
        {
            HP -= HpChangeValue04;
        }
        else if (NowState == 4)
        {
            HP -= HpChangeValue05;
        }
        else if (NowState == 5)
        {
            HP -= HpChangeValue06;
        }
        else if (NowState == 6)
        {
            HP -= HpChangeValue07;
        }
        else if (NowState == 7)
        {
            HP -= HpChangeValue08;
        }
        if (HP >= 100) HP = 100;
        else if(HP <= 0) HP = 0;
    }

    public void OpenLight()
    {
        if (NowState == 7)
        {
            Sound.PlayOneShot(OpenLightS);
            if (!lightRoom.activeSelf)
            {
                remaintime -= lightopentime;
                lightRoom.SetActive(true);
            }
            else lightRoom.SetActive(false);
            if (darkRoom.activeSelf) darkRoom.SetActive(false);
            else darkRoom.SetActive(true);
        }
    }
}
