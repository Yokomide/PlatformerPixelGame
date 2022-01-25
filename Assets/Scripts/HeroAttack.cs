using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public int _heroDamage = 100;
    private Animator _anim;
    
    private bool _isAttackRadius = false;
    private EnemyStats _enemyStats;
    private CapsuleCollider2D _attackZone;
    private AudioSource _attackSound;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _attackZone = gameObject.GetComponent<CapsuleCollider2D>();
        _attackSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _isAttackRadius = true;
            _enemyStats = other.GetComponent<EnemyStats>();
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        _isAttackRadius = false;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            _anim.SetBool("attack", true);
        }
        else
        {
            _anim.SetBool("attack", false);
        }
    }

    void Attack()
    {
        _attackSound.Play();
        if (_isAttackRadius == true)
        {
            _enemyStats._enemyHP = _enemyStats._enemyHP - _heroDamage;
        }
    }

    
}
