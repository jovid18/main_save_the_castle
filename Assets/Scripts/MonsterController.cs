using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    int monsterHP=10;
    Animator animator;
    bool isdead = false;
    float span = 4.0f;
    float delta = 0;
    void Start()
    {
        this.animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
        {
            this.delta += Time.deltaTime;
            if(this.delta> this.span) {
                Destroy(player);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "castle")
        {
            Debug.Log("성");
            this.animator.SetTrigger("toattack");
        }
        else if(other.gameObject.tag == "arrow")
        {
            Debug.Log("화살");
            monsterHP -= 20;
            if (monsterHP < 0)
            {
                this.animator.SetTrigger("todeath");
                isdead = true;
            }
        }
        
    }
}
