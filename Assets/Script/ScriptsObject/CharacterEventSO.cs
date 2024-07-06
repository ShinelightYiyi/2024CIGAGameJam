using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]//asset�ɴ��������ֵ�event
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<Character> onEventRaised;//��һ��character�࣬�����ܵ������в���

    public void RaiseEvent(Character character)
    {
        onEventRaised?.Invoke(character);//�������¼�
    }
}
