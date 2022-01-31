using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats1 : MonoBehaviour
{
    public float maxHeroHp = 100;
    public float HeroHP = 100;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroHP < maxHeroHp)
        {
            maxHeroHp = HeroHP;
            Debug.Log("Сработало");
      
        }
        if (HeroHP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
