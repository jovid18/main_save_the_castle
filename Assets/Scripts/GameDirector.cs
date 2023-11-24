using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hptext;
    int hp;
    public void sethp(int hp)
    {
        this.hp = hp;
    }
    void Start()
    {
        this.hptext = GameObject.Find("HP");
    }

    // Update is called once per frame
    void Update()
    {
        this.hptext.GetComponent<TextMeshProUGUI>().text = "HP: " + this.hp.ToString();
    }
}
