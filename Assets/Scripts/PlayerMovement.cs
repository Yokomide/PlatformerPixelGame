using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _anim;
    
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    private bool jump = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetBool("attack", true);
        }
        else
        {
            _anim.SetBool("attack", false); 
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
            
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false; 
    }
}
