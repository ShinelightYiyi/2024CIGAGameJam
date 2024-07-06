using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPoint : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;
    public Sprite tipSprite;//所需按键图片
    public bool isDone;//所有可互动物品都加这个变量，顾名思义看有没有互动完成

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteRenderer.sprite = tipSprite;
    }
    public void TriggerAction()//实现接口方法,方便进行通用的设置，因为很多对象都需要用触发器互动，但只要继承接口都能进行通用的方法
    {
        // Debug.Log("踩下按键");
        if (!isDone)
        {
            Leave();
        }
    }

    private void Leave()
    {
        isDone = true;
        this.gameObject.tag = "Untagged";
        //Debug.Log("wancheng");
    }
}