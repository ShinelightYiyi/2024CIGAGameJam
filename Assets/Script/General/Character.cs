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
    private void Start()
    {
        invulnarable = true;
        currentHealth = 1;//血量有限等价于不无敌，跳跃次数无限,初始状态跳跃次数无限
        currentJumpCount = maxJumpCount;//转化思路：playercontroller按下confirm键，广播转化，事件监听到，启动订阅函数
        //invulnarable = true;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SpikeWeed"))
        {
            if (invulnarable)
            {//无敌则被弹飞
                EventCenter.Instance.EventTrigger("地刺跳跃");
            }
            else
            {
                currentHealth = 0;
                Debug.Log("死亡");
                EventCenter.Instance.EventTrigger("地刺死亡");
            }
        }
            
    }
}
