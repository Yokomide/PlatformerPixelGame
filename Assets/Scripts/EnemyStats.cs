using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float MaxEnemyHp = 100;
    public float EnemyHP = 100;
    private Sounds _mobSounds;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _mobSounds = GetComponent<Sounds>();
        EnemyHP = MaxEnemyHp;
    }

    public void TakeDamage(int damage)
    {
        EnemyHP -= damage;
        _anim.SetTrigger("takedmg");
        _mobSounds.HitSound();
        if (EnemyHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
