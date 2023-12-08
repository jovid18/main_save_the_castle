using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject director;
    public int towerhp = 100;
    // public int damage = 1;
    // float span = 1.0f;
    float delta = 0;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }
    void Update()
    {
        this.director.GetComponent<GameDirector>().sethp(towerhp);
        if (towerhp <= 0)
        {
            AudioManager.instance.PlayGameOverMusic();
            SceneManager.LoadScene("GameOver Scene");
        }
    }
}