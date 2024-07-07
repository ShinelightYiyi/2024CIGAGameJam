using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    /*[Header("监听事件")]
    public SceneLoadEventSO loadEvent;
    public VoidEventSO afterSceneLoadedEvent;//用于恢复角色控制
    */
    public PlayerInputControll inputControl;
    public Vector2 inputDirection;
    private Rigidbody2D rb;
    private Character character;
    //private CapsuleCollider2D coll;
    //private PhysicsCheck physicsCheck;
    //private PlayerAnimation playerAnimation;
    [Header("基本参数")]
    public float speed;
    public float jumpForce;
    
    [Header("物理材质")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    //private Vector2 originalOffset;
    //private Vector2 originalSize;

    [Header("状态")]
    public bool isBounce;
    public bool isDead;
    public float bounceForce;


    private void Awake()
    {
        
        inputControl = new PlayerInputControll();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        //coll = GetComponent<CapsuleCollider2D>();
        //playerAnimation = GetComponent<PlayerAnimation>();
        
        //跳跃
        inputControl.Gameplay.Jump.started += Jump;//闪电图标中,canceled代表松开，performed为长按，started为按下瞬间
                                                   //把jump函数方法添加到按键按下时刻执行
        inputControl.Gameplay.Jump.started += JumpSound;
        inputControl.Gameplay.Move.performed += MoveSound;

        EventCenter.Instance.AddEventListener("切换状态", () => ChangeCondition());
        EventCenter.Instance.AddEventListener("地刺死亡", () => PlayerDead());
        EventCenter.Instance.AddEventListener("地刺跳跃", () => PlayerBounce());
    }





    private void OnEnable()
    {
        inputControl.Enable();
        //loadEvent.loadRequestEvent += OnLoadEvent;
       // afterSceneLoadedEvent.onEventRaised += OnAfterSceneLoadedEvent;
    }



    private void OnDisable()
    {
        inputControl.Disable();
        //loadEvent.loadRequestEvent -= OnLoadEvent;
        //afterSceneLoadedEvent.onEventRaised -= OnAfterSceneLoadedEvent;
    }



    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();

        //CheckState();
    }
    private void FixedUpdate()
    {
        if (!isDead)
            Move();//死亡时不能按按键移动
    }

    /*private void OnLoadEvent(GameSceneSO sO, Vector3 vector, bool arg3)
    {
        inputControl.Gameplay.Disable();//加载时不能控制人物
    }*/
    private void OnAfterSceneLoadedEvent()
    {
        inputControl.Gameplay.Enable();
    }

    private void MoveSound(InputAction.CallbackContext context)
    {
        AudioManager.Instance.PlaySound("Audio/sound_game_stonestep1");
    }

    private void JumpSound(InputAction.CallbackContext context)
    {
        AudioManager.Instance.PlaySound("Audio/sound_game_meow1");
    }

    public void Move()
    {

        //if (!isCrouch)
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
    

        int facedir = (int)transform.localScale.x;//面朝方向
        if (inputDirection.x > 0 && facedir<0)
            facedir = -facedir;
        if (inputDirection.x < 0 && facedir >0)
            facedir = -facedir;
         transform.localScale = new Vector3(facedir, transform.localScale.y, transform.localScale.z);//这样翻转需要贴图锚点在脚底中央
        //输入transform时有两个选项，扳手是变量，后者是类型
        //也可以用spriterenderer的flip翻转，获取该组件方式和rigidbody一样

    }

    /// <summary>
    /// 跳跃
    /// </summary>
    /// <param name="context"></param>
    private void Jump(InputAction.CallbackContext context)
    {
        if (character.currentJumpCount > 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (character.invulnarable)//如果无限血，减跳跃次数
        {
            character.currentJumpCount -= 1;
        }
        else
        {
            character.currentJumpCount = character.maxJumpCount;
        }
        //GetComponent<AudioDefination>()?.PlayAudioClip();
       
        //impulse为冲量
    }

    private void ChangeCondition()
    {
        character.invulnarable = !character.invulnarable;//转换状态

    }

    #region UnityEvent
    /*public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;//受伤时先将速度归零
        Vector2 dir = new Vector2(transform.position.x - attacker.position.x, 0).normalized;//取得受伤方向的单位向量
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);//加一个瞬时力
    }*/

    public void PlayerDead()
    {
        EventCenter.Instance.EventTrigger("死亡");
        isDead = true;
        inputControl.Gameplay.Disable();//不能输入游戏操作，ui操作正常
    }

    public void PlayerBounce()
    {
        isBounce = true;
        rb.velocity = Vector2.zero;//先将速度归零
        Vector2 dir = new Vector2(0, 1).normalized;
        rb.AddForce(dir * bounceForce * 2, ForceMode2D.Impulse);//加一个瞬时力
    }
    #endregion

    /*private void CheckState()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }*/
}
