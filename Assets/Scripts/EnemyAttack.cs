using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Core.Character;
using System;


public class EnemyAttack : MonoBehaviour
{
    public Animator _anim;
    private bool _isAttackZone = false;
    [SerializeField] private int _damage = 20;
    public bool IsDead { get; protected set; }
    public bool CanMove { get; set; }
    public bool IsMoving { get; set; }

    protected PlayerMovement player;

    public event Action OnPlayerHurt;


    protected virtual void OnHitPlayer(Vector2 hitVelocity)
    {
        OnPlayerHurt?.Invoke();
    }
    void Start()
    {
        _anim = GetComponent<Animator>();
        player = PlayerMovement.Instance;
    }

    /*
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
    */
    /*
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
    */
    /*
    void Enemy_Attack(){
        if (_herStats != null)
        {
         _herStats.HeroHP = _herStats.HeroHP - _damage;
        } 
    }
    */

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsDead) return;
            if (!player.CanBeHit) return;

            Vector2 recoilForce =
                new Vector2(-collision.relativeVelocity.normalized.x, -collision.relativeVelocity.normalized.y) *
                500.0f;
            player.Hurt(20, recoilForce);

            OnHitPlayer(collision.relativeVelocity);
            
        }
    }



}
