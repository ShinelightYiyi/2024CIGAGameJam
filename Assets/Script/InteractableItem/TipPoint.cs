using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPoint : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;
    public Sprite tipSprite;//���谴��ͼƬ
    public bool isDone;//���пɻ�����Ʒ�����������������˼�忴��û�л������

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteRenderer.sprite = tipSprite;
    }
    public void TriggerAction()//ʵ�ֽӿڷ���,�������ͨ�õ����ã���Ϊ�ܶ������Ҫ�ô�������������ֻҪ�̳нӿڶ��ܽ���ͨ�õķ���
    {
        // Debug.Log("���°���");
        if (!isDone)
        {
            Leave();
        }
    }

    private void Leave()
    {
        isDone = true;
        this.gameObject.tag = "Untagged";
        //Debug.Log("wancheng");
    }
}