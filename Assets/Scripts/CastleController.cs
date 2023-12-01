using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject director;
    public int towerhp = 100;
    float span = 1.0f;
    float delta = 0;
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }
    private void OnTriggerStay(Collider other)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            if (other.gameObject.tag == "Demon")
            {
                this.delta = 0;
                towerhp -= 5;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("GameOver Scene");
                }
            }
            if (other.gameObject.tag == "UmbrellaYokai")
            {
                this.delta = 0;
                towerhp -= 1;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("GameOver Scene");
                }
            }
            if (other.gameObject.tag == "Giant")
            {
                this.delta = 0;
                towerhp -= 20;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("GameOver Scene");
                }
            }
            if (other.gameObject.tag == "LampOni")
            {
                this.delta = 0;
                towerhp -= 10;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("GameOver Scene");
                }
            }
            if (other.gameObject.tag == "OniSamurai2")
            {
                this.delta = 0;
                towerhp -= 1;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("GameOver Scene");
                }
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
            this.director.GetComponent<GameDirector>().sethp(towerhp);
        
        
    }
}
