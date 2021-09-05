using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
