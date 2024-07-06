using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvertDevice : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;
    public Sprite lifeLimitLessSprite;//����Ѫ������ͼƬ����������Ծ������һ��һ��
    public Sprite jumpLimitLessSprite;
    public UnityEvent onInvert;
    public bool isDone;//���пɻ�����Ʒ�����������������˼�忴��û�л�����ɣ��˴����ڼ�¼������������ż�ԣ�falseΪ������Ծ��������֮Ϊ����Ѫ��

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteRenderer.sprite = isDone ? jumpLimitLessSprite : lifeLimitLessSprite;//��ϰ�����Ԫ�����
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
        spriteRenderer.sprite = jumpLimitLessSprite;
        isDone = !isDone;
        onInvert?.Invoke();
        //this.gameObject.tag = "Untagged";
    }
}