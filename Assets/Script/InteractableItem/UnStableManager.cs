using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnStableManager : MonoBehaviour
{
    bool isWorking;

    int o;
    float timer;

    [SerializeField] BoxCollider2D theGround;
    [SerializeField] Animator ani;

    private void Start()
    {
        isWorking = false;
        o = 0;
        timer = 0;
    }

    private void FixedUpdate()
    {
        if(o == 1)
        {
            isWorking=true;
            timer += Time.fixedDeltaTime;
            if (timer > 2)
            {
                TheOnDestroy();
                timer = 0;
                isWorking = false;
                o = 2;
            }


        }
        else if(o == 2)
        {
            isWorking = true; 
            timer += Time.fixedDeltaTime;
            if (timer > 4)
            {
                OnRebuild();
                timer = 0;
                isWorking=false;
                o = 0;
            }
        }
    }

    private void OnRebuild()
    {
        theGround.isTrigger = false;
        ani.SetBool("isDestory", false);
    }

    private void TheOnDestroy()
    {
        theGround.isTrigger = true;
        ani.SetBool("isDestory", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isWorking)
        {
            if (collision.tag == "Player")
            {
                o = 1;
            }
        }
    }




}
