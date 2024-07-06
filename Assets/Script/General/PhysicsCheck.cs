using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private CapsuleCollider2D coll;
    [Header("������")]
    public bool manual;//�ֶ�
    public float checkRadius;
    public LayerMask groundLayer;//�����ײ��һ��
    public Vector2 bottomOffset;//���ĵ���ŵ׵�ƫ��,�е�������Ҫ���ǰ���Ƿ������£����ҵ������ĵ�λ�ÿ������ͷ
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    [Header("״̬")]
    public bool isGround;
    public bool touchLeftWall;
    public bool touchRightWall;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        if (!manual)
        {
            rightOffset = new Vector2(coll.bounds.size.x / 2 + coll.offset.x, coll.bounds.size.y / 2);
            leftOffset = new Vector2(-rightOffset.x, rightOffset.y);
        }
    }
    void Update()
    {
        Check();
    }

    public void Check()//������
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset * transform.localScale, checkRadius, groundLayer);//�������кܶ��ʽ���ú����ܼ���ض�ͼ�����ײ
                                                                                                                                        //�ڱ༭����ѡ�ж���w��ʾ����
                                                                                                                                        //��ʼ����������ײ���

        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRadius, groundLayer); //ǽ����
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRadius, groundLayer);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);//ֱ����ʾ����λ��,ͬʱ���ڵ���
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRadius);
    }
}
