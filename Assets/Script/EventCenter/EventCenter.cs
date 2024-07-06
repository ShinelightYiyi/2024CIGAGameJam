using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventCenter
{
    //����ģʽ
    private static EventCenter instance;
    public static EventCenter GetInstance()
    {
        if (instance == null)
            instance = new EventCenter();
        return instance;
    }

    //ʹ�ò���Ϊobject��Unity�Դ�ί�����ֵ��ֵ
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    /// <summary>
    ///����¼�����
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="action">�����������Ҫ������Ӧ�¼���ί�к�����</param>
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

    //�Ƴ��¼�����
    public void RemoveEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
    }

    /// <summary>
    /// �¼�����
    /// </summary>
    /// <param name="name">��Ҫ�������¼���</param>
    /// <param name="info">����</param>
    public void EventTrigger(string name, object info)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke(info);
        }
    }

    //����¼�����
    public void Clear()
    {
        eventDic.Clear();
    }
}
