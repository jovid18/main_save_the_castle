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
    public int monsterDamage = 1;
    public float span = 1.0f;
    public float timeToDestroy = 6.0f;
    public bool whetherDestroy = false;

    public AudioSource attackAudioSource = null;
    public AudioClip[] attackSounds;

    public AudioSource deathAudioSource = null;
    public AudioClip[] deathSounds;

    public bool isdead = false;
    private float delta = 0;
    private float CastleDelta = 0;

    private Animator _animator;
    private Collider _collider;

    
    void Start()
    {

        if (gameObject.tag == "Demon")
        {
            monsterHP = 30;
            monsterDamage = 5;
            span = 2.967f;
            CastleDelta = span - 1.04f;
        }
        else if (gameObject.tag == "Giant" && GameDirector.lv.Equals(GameDirector.level.Medium))
        {
            monsterHP = 40;
            monsterDamage = 20;
            span = 2.667f;
            CastleDelta = span - 1.09f;
        }
        else if (gameObject.tag == "Giant" && GameDirector.lv.Equals(GameDirector.level.Hard))
        {
            monsterHP = 60;
            monsterDamage = 20;
            span = 2.667f;
            CastleDelta = span - 1.09f;
        }
        else if (gameObject.tag == "UmbrellaYokai")
        {
            monsterHP = 10;
            monsterDamage = 1;
            span = 2.967f;
            CastleDelta = span - 1.14f;
        }
        else if (gameObject.tag == "OniSamurai2")
        {
            monsterHP = 10;
            monsterDamage = 1;
            span = 2.267f;
            CastleDelta = span - 0.26f;
        }
        else if (gameObject.tag == "LampOni")
        {
            monsterHP = 10;
            monsterDamage = 10;
            span = 2.967f;
            CastleDelta = span / 2.0f;
        }

        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead && whetherDestroy)
        {
            delta += Time.deltaTime;
            if (delta > timeToDestroy)
            {
                Destroy(gameObject);
                isdead = false;
            }
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "castle")
        {
            CastleDelta += Time.deltaTime;
            if (this.CastleDelta > this.span)
            {
                other.GetComponent<CastleController>().towerhp -= monsterDamage;
                StartCoroutine(attackSound());
                this.CastleDelta = 0;
                // this.CastleDelta = -this.span / 2.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "castle")
        {
            Debug.Log($"Object: {gameObject.name}, collide with castle");

            this._animator.SetTrigger("ToAttack");
        }
        else if (other.gameObject.tag == "arrow")
        {

            // 화살의 NonKineCollision 컴포넌트를 찾습니다.
            NonKineCollision arrowCollision = other.GetComponent<NonKineCollision>();
            // 화살이 이미 충돌했는지 확인합니다.
            if (arrowCollision != null && arrowCollision.hasCollided)
            {
                
                return; // 이미 충돌한 화살이면 추가 처리를 하지 않습니다.
            }
            // 충돌한 경우 arrowCollision의 hasCollided를 True로 바꿔 해당 화살이 다른 적과 트리거 되지 않도록 함.
            arrowCollision.hasCollided = true;
            
            monsterHP -= 10;
            if (monsterHP <= 0) // monster dead
            {
                // transite to death animation
                _animator.SetTrigger("ToDeath");

                // disable current monster's collider
                // so that newly released arrow does not interact with this dead monster
                _collider.enabled = false;

                // set death sound
                StartCoroutine(deathSound());

                // state changed
                isdead = true;
            }
        }

    }
    /*
    public void PlayAttackSound(GameObject gameObject)
    {
        attackAudioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
        attackAudioSource.Play();
    }
    */
    IEnumerator attackSound()
    {
        if (attackAudioSource == null)
        {
            attackAudioSource = gameObject.AddComponent<AudioSource>();
        }
        attackAudioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
        attackAudioSource.volume = 0.1f;
        attackAudioSource.Play();
        yield return null;
    }

    IEnumerator deathSound()
    {
        if (deathAudioSource == null)
        {
            deathAudioSource = gameObject.AddComponent<AudioSource>();
        }
        deathAudioSource.clip = deathSounds[Random.Range(0, deathSounds.Length)];
        deathAudioSource.volume = 0.1f;
        deathAudioSource.Play();
        yield return null;
    }
}
