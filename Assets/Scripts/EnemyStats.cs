using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float _maxEnemyHp = 100;
    public float _enemyHP = 100;
    private Sounds _mobSounds;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _mobSounds = GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyHP < _maxEnemyHp)
        {
            _anim.SetTrigger("takedmg");
            _maxEnemyHp = _enemyHP;
            _mobSounds.HitSound();
        }
            if (_enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
