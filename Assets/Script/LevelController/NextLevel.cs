using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("����");
            EventCenter.Instance.EventTrigger<string>("��һ��", nextLevel);
        }
    }
}
