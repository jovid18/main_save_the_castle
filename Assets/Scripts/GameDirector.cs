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
    public enum level
    {
        Easy=1,
        Medium=2,
        Hard=3
    };
    public level lv;
    bool isclear = false;
    int hp;
    public void sethp(int hp)
    {
        this.hp = hp;
    }
    void Start()
    {
        this.hptext = GameObject.Find("HP");
        lv = level.Hard;
    }

    // Update is called once per frame
    void Update()
    {
        //isclear가 true면 클리어씬으로 전환
        if (isclear)
        {
            isclear = false;
            SceneManager.LoadScene("Size modified Clearscene");
        }
        //각 level에 맞게 몬스터 스폰
        if (lv.Equals(level.Easy))
        {

        }else if (lv.Equals(level.Medium))
        {

        }
        else
        {

        }
        this.hptext.GetComponent<TextMeshProUGUI>().text = "HP: " + this.hp.ToString();
    }
}
