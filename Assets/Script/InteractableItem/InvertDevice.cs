using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvertDevice : MonoBehaviour, IInteractable
{


    public UnityEvent onInvert;
    public bool isDone;//���пɻ�����Ʒ�����������������˼�忴��û�л�����ɣ��˴����ڼ�¼������������ż�ԣ�falseΪ������Ծ��������֮Ϊ����Ѫ��

    private void Awake()
    {
       
    }

    public void TriggerAction()//ʵ�ֽӿڷ���,�������ͨ�õ����ã���Ϊ�ܶ������Ҫ�ô�������������ֻҪ�̳нӿڶ��ܽ���ͨ�õķ���
    {
        // Debug.Log("���°���");
        if (!isDone)
        {
            Invert();
        }
    }

    private void Invert()
    {

        isDone = !isDone;
        if (isDone)
            Debug.Log("��ǰ������Ѫ��״̬");
        else
            Debug.Log("��ǰ��������Ծ״̬");
        onInvert?.Invoke();
        //this.gameObject.tag = "Untagged";
    }
}