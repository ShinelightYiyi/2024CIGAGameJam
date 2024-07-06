using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]//asset可创建此名字的event
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<Character> onEventRaised;//传一个character类，但不能调用其中参数

    public void RaiseEvent(Character character)
    {
        onEventRaised?.Invoke(character);//启动该事件
    }
}
