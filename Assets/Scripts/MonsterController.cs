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
    public DeathSound deathSoundScript; // deathSound


    private Animator animator;
    private bool isdead = false;
    private float delta = 0;


    void Start()
    {
        deathSoundScript = GetComponent<DeathSound>(); // deathSound

        if (gameObject.tag == "Demon")
        {
            monsterHP = 30;
        }
        else if(gameObject.tag == "Giant" && GameDirector.lv.Equals(GameDirector.level.Medium))
        {
            monsterHP = 40;
        }
        else if (gameObject.tag == "Giant" && GameDirector.lv.Equals(GameDirector.level.Hard))
        {
            monsterHP = 60;
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
            //Debug.Log($"Object: {gameObject.name}, collide with arrow");

            // 화살의 NonKineCollision 컴포넌트를 찾습니다.
            NonKineCollision arrowCollision = other.GetComponent<NonKineCollision>();
            // 화살이 이미 충돌했는지 확인합니다.
            if (arrowCollision != null && arrowCollision.hasCollided)
            {
                // Debug.Log("arrowCollision: Just Return");
                return; // 이미 충돌한 화살이면 추가 처리를 하지 않습니다.
            }
            // 충돌한 경우 arrowCollision의 hasCollided를 True로 바꿔 해당 화살이 다른 적과 트리거 되지 않도록 함.
            arrowCollision.hasCollided = true;
            Debug.Log($"Object: {gameObject.name}, collide with arrow. \n" +
                $"Arrow has collided: {arrowCollision.hasCollided }");

            monsterHP -= 10;
            if (monsterHP <= 0)
            {
                // transite to death animation
                animator.SetTrigger("ToDeath");
                Debug.Log($"Object: {gameObject.name}, DIE");

                // adjust object y position when died.
                Vector3 currentPosition = gameObject.transform.position;
                currentPosition.y -= 1f; 
                gameObject.transform.position = currentPosition;
                
                isdead = true;
                deathSoundScript.sound(gameObject); // deathSound
            }
        }
        
    }
}
