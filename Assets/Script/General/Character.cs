using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("����״̬")]
    public bool invulnarable;
    public int currentHealth;
    public int currentJumpCount;
    public int maxJumpCount;
    public UnityEvent onDie;
    public UnityEvent onBounce;
    private void Start()
    {
        currentHealth = 1;//Ѫ�����޵ȼ��ڲ��޵У���Ծ��������,��ʼ״̬��Ծ��������
        currentJumpCount = maxJumpCount;//ת��˼·��playercontroller����confirm�����㲥ת�����¼����������������ĺ���
        //invulnarable = true;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SpikeWeed"))
        {
           if (invulnarable)
          {
            onBounce?.Invoke();//�޵��򱻵���
          }
           else
          {
            //��������������Ѫ����������Ч
            currentHealth = 0;
                Debug.Log("����");
            onDie?.Invoke();
          }
        }
            
    }
}
