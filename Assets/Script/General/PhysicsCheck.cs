using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private CapsuleCollider2D coll;
    [Header("检测参数")]
    public bool manual;//手动
    public float checkRadius;
    public LayerMask groundLayer;//检测碰撞哪一层
    public Vector2 bottomOffset;//中心点与脚底的偏移,有的物体需要检测前方是否有悬崖，左右调整中心点位置控制其掉头
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    [Header("状态")]
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

    public void Check()//检测地面
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset * transform.localScale, checkRadius, groundLayer);//括号内有很多格式，该函数能检测特定图层的碰撞
                                                                                                                                        //在编辑器内选中对象按w显示坐标
                                                                                                                                        //起始点与地面的碰撞检测

        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRadius, groundLayer); //墙体检测
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRadius, groundLayer);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);//直观显示监测点位置,同时便于调整
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRadius);
    }
}
