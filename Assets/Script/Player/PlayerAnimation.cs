using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;

    bool isCat;
    private void Awake()
    {
        isCat = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        anim.SetBool("isCat", false);
        EventCenter.Instance.AddEventListener("ÇÐ»»×´Ì¬", () => ChangeCondition());

        EventCenter.Instance.AddEventListener("´©Ëó¿ªÊ¼", () => StartTrough());
        EventCenter.Instance.AddEventListener("´©Ëó½áÊø", () => EndTrough());
    }

    private void Update()
    {
        anim.SetFloat("velocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", Mathf.Abs(rb.velocity.y));
        anim.SetBool("isGround", physicsCheck.isGround);
        //anim.SetBool("isFlow",)

        if(isCat)
        {
            anim.SetBool("isCat", true);
        }
        else if(!isCat) 
        {
            anim.SetBool("isCat", false);
        }
    }

    private void StartTrough()
    {
        anim.SetBool("isFlow", true);
    }

    private void EndTrough()
    {
        anim.SetBool("isFlow", false);
    }

    private void ChangeCondition()
    {
        isCat = !isCat;
    }

}
