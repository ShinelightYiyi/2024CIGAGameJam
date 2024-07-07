using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvertDevice : MonoBehaviour, IInteractable
{


    public UnityEvent onInvert;
    public bool isDone;//所有可互动物品都加这个变量，顾名思义看有没有互动完成，此处用于记录互动次数的奇偶性，false为无限跳跃次数，反之为无限血量

    private void Awake()
    {
       
    }

    public void TriggerAction()//实现接口方法,方便进行通用的设置，因为很多对象都需要用触发器互动，但只要继承接口都能进行通用的方法
    {
        // Debug.Log("踩下按键");
        if (!isDone)
        {
            Invert();
        }
    }

    private void Invert()
    {

        isDone = !isDone;
        if (isDone)
            Debug.Log("当前是无限血量状态");
        else
            Debug.Log("当前是无限跳跃状态");
        onInvert?.Invoke();
        //this.gameObject.tag = "Untagged";
    }
}