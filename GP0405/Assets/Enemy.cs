using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    bool isDie = false;
    float dieTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            SoundManager.instance.HitSound();
            Destroy(gameObject, 2);
        }
           
    }

    public void Die()
    {
        anim.SetBool("isDie", true);
        isDie = true;
    }
}
