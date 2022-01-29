using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float _moveSpeed = 1.5f;
    public Transform Hero;
    private Rigidbody2D rigidbody2D;
    private  Vector2 theScale;
    public float angerZone = 5f;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        Hero = GameObject.FindWithTag("Player").GetComponent<Transform>();
        theScale = transform.localScale;
     rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, Hero.position);
        if((distToPlayer <= angerZone) && (distToPlayer>1f))
        {
           StartChase();
        }
        if (distToPlayer <= 1f)
        {
            StopChase();   
        }
        if(distToPlayer >= angerZone)
        {
            _anim.SetBool("walking", false);
        }

    }

    void StartChase()
    {
        _anim.SetBool("walking", true);
        if(transform.position.x < Hero.transform.position.x)
        {
            rigidbody2D.velocity = new Vector2(_moveSpeed, -1.5f);
            transform.localScale = new Vector2(-theScale.x, theScale.y);
        }
        else if (transform.position.x > Hero.transform.position.x)
        {
            rigidbody2D.velocity = new Vector2(-_moveSpeed, -1.5f);
            transform.localScale = new Vector2(theScale.x, theScale.y);
        }
    }

    void StopChase(){
        rigidbody2D.velocity = new Vector2(0,-1.5f);
    }

    public void StopAttack()
    {
        rigidbody2D.velocity = new Vector2(0, -1.5f);
    }


}
