using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    // set public
    public int monsterHP = 10;
    public float timeToDestroy = 6.0f;
    public bool whetherDestroy = false;


    private Animator animator;
    private bool isdead = false;
    private float delta = 0;


    void Start()
    {
        if(gameObject.tag == "Demon")
        {
            monsterHP = 30;
        }
        else if(gameObject.tag == "Giant")
        {
            monsterHP = 50;
        }
        else if (gameObject.tag == "UmbrellaYokai")
        {
            monsterHP = 10;
        }
        else if (gameObject.tag == "OniSamurai2")
        {
            monsterHP = 10;
        }
        else if (gameObject.tag == "LampOni")
        {
            monsterHP = 10;
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead && whetherDestroy)
        {
            delta += Time.deltaTime;
            if(delta > timeToDestroy) {
                Destroy(gameObject);
                isdead = false;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "castle")
        {
            Debug.Log($"Object: {gameObject.name}, collide with castle");
            
            this.animator.SetTrigger("ToAttack");
        }
        else if(other.gameObject.tag == "arrow")
        {
            Debug.Log($"Object: {gameObject.name}, collide with arrow");
            monsterHP -= 10;
            if (monsterHP < 0)
            {
                // transite to death animation
                animator.SetTrigger("ToDeath");

                // adjust object y position when died.
                Vector3 currentPosition = gameObject.transform.position;
                currentPosition.y -= 1f; 
                gameObject.transform.position = currentPosition;
                
                isdead = true;
            }
        }
        
    }
}
