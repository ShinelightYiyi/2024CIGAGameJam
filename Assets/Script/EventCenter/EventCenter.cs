using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IEventInfo
{

}


public class EventInfo :IEventInfo
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}


public class EventInfo<T> :IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo( UnityAction<T> action)
    {
        actions += action;
    }

}

public class EventCenter  //通知者
{
    private static EventCenter instance;
    public static EventCenter Instance { get => instance ?? (instance = new EventCenter()); }
    //单例模式  


    /// <summary>
    /// key--事件名   value--对应委托
    /// </summary>
    private static Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();



    /// <summary>
    /// 为事件添加泛型委托
    /// </summary>
    /// <typeparam 委托类型="T"></typeparam>
    /// <param name=委托名></param>
    /// <param name=具体委托></param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        //是否已有对应事件  
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }


    /// <summary>
    /// 为事件添加委托
    /// </summary>
    /// <param name=委托名></param>
    /// <param name=具体委托></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// 移除泛型事件
    /// </summary>
    /// <typeparam 委托类型="T"></typeparam>
    /// <param name=事件名></param>
    /// <param name=具体委托></param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }


    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }


    /// <summary>
    /// 触发泛型事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="info"></param>
    public void EventTrigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null)
            {
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
            }
        }
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
            {
                (eventDic[name] as EventInfo).actions.Invoke();
            }
        }
    }

    /// <summary>
    /// 清空字典，切换场景时使用
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }


}


