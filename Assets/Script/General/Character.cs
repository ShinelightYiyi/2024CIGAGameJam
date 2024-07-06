using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("基础状态")]
    public bool invulnarable;
    public int currentHealth;
    public int currentJumpCount;
    public int maxJumpCount;
    public UnityEvent onDie;
    public UnityEvent onBounce;
    private void Start()
    {
        currentHealth = 1;//血量有限等价于不无敌，跳跃次数无限,初始状态跳跃次数无限
        currentJumpCount = maxJumpCount;//转化思路：playercontroller按下confirm键，广播转化，事件监听到，启动订阅函数
        //invulnarable = true;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SpikeWeed"))
        {
           if (invulnarable)
          {
            onBounce?.Invoke();//无敌则被弹飞
          }
           else
          {
            //否则死亡、更新血量、播放音效
            currentHealth = 0;
                Debug.Log("死亡");
            onDie?.Invoke();
          }
        }
            
    }
}
