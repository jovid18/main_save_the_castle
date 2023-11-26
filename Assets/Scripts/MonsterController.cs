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
