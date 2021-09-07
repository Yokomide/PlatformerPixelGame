using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour
{
    private bool _isActive = false;
    private bool _isOnTrigger = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        _isOnTrigger = true;

    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        _isActive = false;
        _isOnTrigger = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isActive && _isOnTrigger)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            _isActive = true;
            Debug.Log(_isActive);
        }
        else if (Input.GetKeyDown(KeyCode.E) && _isActive && _isOnTrigger)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            _isActive = false;
        }
    }
}
