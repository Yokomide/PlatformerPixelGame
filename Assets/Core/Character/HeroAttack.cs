using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float attackRange = 0.5f;

    public int attackDamage = 20;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private Animator _anim;
    private AudioSource _attackSound;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _attackSound = GetComponent<AudioSource>();
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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);
        }
        _attackSound.Play();
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
