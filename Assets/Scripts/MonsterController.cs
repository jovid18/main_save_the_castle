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

    private Animator animator;
    private bool isdead = false;
    private float span = 6.0f;
    private float delta = 0;

    //private NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
        {
            delta += Time.deltaTime;
            if(delta > span) {
                Destroy(gameObject);
                isdead = false;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "castle")
        {
            Debug.Log("Castle");
            this.animator.SetTrigger("ToAttack");
        }
        else if(other.gameObject.tag == "arrow")
        {
            Debug.Log("Arrow");
            monsterHP -= 20;
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
