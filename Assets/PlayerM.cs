using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float maxJumpForce = 8f;

    private float _speed;
    private Vector2 _move = new Vector2();

    private Rigidbody2D _rb;
    private bool _isFacingRight = true;

    private bool _isWall;
    private bool _isGrounded = true;
    void Start()
    {   
        _speed = 0;
        _rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = Input.GetAxis("Horizontal");

        if (_speed < 0 && _isFacingRight)
        {
            Flip();
        }
        else if (_speed > 0 && !_isFacingRight)
        {
            Flip();
        }

        //if (_isWall == false)
        //{
        _rb.velocity = new Vector2(_speed * maxSpeed, _rb.velocity.y);
        //}
        //_rb.MovePosition(new Vector2((gameObject.transform.position.x + _speed), gameObject.transform.position.y));

        if (Input.GetKeyDown(KeyCode.Space)&& _isGrounded)
        {
            Jump();
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        _isFacingRight = !_isFacingRight;
    }

    void Jump()
    {
        _isGrounded = false;
        _rb.AddForce(Vector2.up * maxJumpForce);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
        if(other.gameObject.tag == "Wall")
        {
            _isWall = true;
            
        }
        
    }
}
