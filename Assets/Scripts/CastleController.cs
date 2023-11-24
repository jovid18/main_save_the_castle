using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject director;
    int towerhp = 2000;
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
            if (other.gameObject.tag == "monster")
            {
                this.delta = 0;
                towerhp -= 1;
                if (towerhp <= 0)
                {
                    SceneManager.LoadScene("Seonghyeon Endingscene");
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
