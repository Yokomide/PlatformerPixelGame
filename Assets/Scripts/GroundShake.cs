using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    private GameObject cam;
    private Animator _camAnim;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera");
        _camAnim = cam.GetComponent<Animator>();
    }
    void OnColliderEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _camAnim.SetTrigger("Shake");
        }
    }

}
