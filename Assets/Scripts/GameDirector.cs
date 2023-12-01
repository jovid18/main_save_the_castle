using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hptext;
    float playtime=0;
    float cleartime = 300f;
    public enum level
    {
        Easy=1,
        Medium=2,
        Hard=3
    };
    public static level lv=level.Medium;
    public static bool[] skill=new bool[3];
    
    int hp;
    public void sethp(int hp)
    {
        this.hp = hp;
    }
    void Start()
    {
        this.hptext = GameObject.Find("HP");
        if (lv.Equals(level.Easy))
        {
            cleartime= 90f;
        }else if (lv.Equals(level.Medium))
        {
            cleartime = 120f;
        }
        else if (lv.Equals(level.Hard))
        {
            cleartime = 150f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //isclear가 true면 클리어씬으로 전환
        playtime += Time.deltaTime;
        if (playtime>cleartime)
        {
            SceneManager.LoadScene("Size modified Clearscene");
        }
        this.hptext.GetComponent<TextMeshProUGUI>().text = "HP: " + this.hp.ToString();
    }
}
