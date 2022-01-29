using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator _anim;
    public PlayerMovement _herStats;
    private bool _isAttackZone = false;
    [SerializeField] private int _damage = 20;
    
    
    void Start(){
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _herStats= other.GetComponent<PlayerMovement>();
            _isAttackZone = true;
        }
    }
    
     private void OnTriggerExit2D(Collider2D other)
    {
        _herStats = null;
        _isAttackZone = false;
    }

    void Update()
    {
         if(_isAttackZone == true){
            _anim.SetBool("attack", true);
            gameObject.GetComponent<EnemyMove>().StopAttack();
        }
        else{

            _anim.SetBool("attack", false);
        }
    }
    void Enemy_Attack(){
        if (_herStats != null)
        {
         _herStats.HeroHP = _herStats.HeroHP - _damage;
        } 
    }

}
