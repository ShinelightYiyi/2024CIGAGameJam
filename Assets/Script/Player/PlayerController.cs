using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    /*[Header("�����¼�")]
    public SceneLoadEventSO loadEvent;
    public VoidEventSO afterSceneLoadedEvent;//���ڻָ���ɫ����
    */
    public PlayerInputControll inputControl;
    public Vector2 inputDirection;
    private Rigidbody2D rb;
    private Character character;
    //private CapsuleCollider2D coll;
    //private PhysicsCheck physicsCheck;
    //private PlayerAnimation playerAnimation;
    [Header("��������")]
    public float speed;
    public float jumpForce;
    
    [Header("��������")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;
    //private Vector2 originalOffset;
    //private Vector2 originalSize;

    [Header("״̬")]
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
        
        //��Ծ
        inputControl.Gameplay.Jump.started += Jump;//����ͼ����,canceled�����ɿ���performedΪ������startedΪ����˲��
        //��jump�����������ӵ���������ʱ��ִ��
        inputControl.Gameplay.Confirm.started += Confirm;
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
            Move();//����ʱ���ܰ������ƶ�
    }

    /*private void OnLoadEvent(GameSceneSO sO, Vector3 vector, bool arg3)
    {
        inputControl.Gameplay.Disable();//����ʱ���ܿ�������
    }*/
    private void OnAfterSceneLoadedEvent()
    {
        inputControl.Gameplay.Enable();
    }

    public void Move()
    {

        //if (!isCrouch)
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);


        int facedir = (int)transform.localScale.x;//�泯����
        if (inputDirection.x > 0)
            facedir = 1;
        if (inputDirection.x < 0)
            facedir = -1;
        transform.localScale = new Vector3(facedir, 1, 1);//������ת��Ҫ��ͼê���ڽŵ�����
        //����transformʱ������ѡ������Ǳ���������������
        //Ҳ������spriterenderer��flip��ת����ȡ�������ʽ��rigidbodyһ��

        
    }

    /// <summary>
    /// ��Ծ
    /// </summary>
    /// <param name="context"></param>
    private void Jump(InputAction.CallbackContext context)
    {
        if(character.currentJumpCount>0)
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (character.invulnarable)//�������Ѫ������Ծ����
            character.currentJumpCount -= 1;
        else
            character.currentJumpCount = character.maxJumpCount;
        //GetComponent<AudioDefination>()?.PlayAudioClip();
       
        //impulseΪ����
    }

    private void Confirm(InputAction.CallbackContext context)
    {
        character.invulnarable = !character.invulnarable;//ת��״̬

    }

    #region UnityEvent
    /*public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;//����ʱ�Ƚ��ٶȹ���
        Vector2 dir = new Vector2(transform.position.x - attacker.position.x, 0).normalized;//ȡ�����˷���ĵ�λ����
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);//��һ��˲ʱ��
    }*/

    public void PlayerDead()
    {
        isDead = true;
        inputControl.Gameplay.Disable();//����������Ϸ������ui��������
    }

    public void PlayerBounce()
    {
        isBounce = true;
        rb.velocity = Vector2.zero;//�Ƚ��ٶȹ���
        Vector2 dir = new Vector2(0, 1).normalized;
        rb.AddForce(dir * bounceForce, ForceMode2D.Impulse);//��һ��˲ʱ��
    }
    #endregion

    /*private void CheckState()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }*/
}