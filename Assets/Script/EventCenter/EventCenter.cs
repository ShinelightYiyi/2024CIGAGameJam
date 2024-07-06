using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventCenter
{
    //单例模式
    private static EventCenter instance;
    public static EventCenter GetInstance()
    {
        if (instance == null)
            instance = new EventCenter();
        return instance;
    }

    //使用参数为object的Unity自带委托作字典的值
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    /// <summary>
    ///添加事件监听
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">“结果”（需要监听对应事件的委托函数）</param>
    public void AddEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        else
        {
            eventDic.Add(name, action);
        }
    }

    //移除事件监听
    public void RemoveEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">需要触发的事件名</param>
    /// <param name="info">参数</param>
    public void EventTrigger(string name, object info)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke(info);
        }
    }

    //清空事件中心
    public void Clear()
    {
        eventDic.Clear();
    }
}
