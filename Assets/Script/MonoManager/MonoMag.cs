using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoMag : MonoBehaviour
{
    private static UnityAction updateEvent;



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (updateEvent != null)
        {
            updateEvent();
        }
    }



    public void AddUpdateListener(UnityAction action)
    {
        updateEvent += action;
    }

    public void RemoveUpdateListener(UnityAction action)
    {
        updateEvent -= action;
    }


    /// <summary>
    /// 清空事件，切换场景时使用
    /// </summary>
    public void Clear()
    {
        updateEvent = null;
    }
}
