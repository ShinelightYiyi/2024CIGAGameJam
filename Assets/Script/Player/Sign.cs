using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;


/// <summary>
/// 显示是否可交互
/// </summary>

public class Sign : MonoBehaviour
{
    private PlayerInputControll playerInput;
    private Animator anim;
    private bool canPress;
    private IInteractable targetItem;
    public GameObject signSprite;
    public Transform playerTrans;

    private void Awake()
    {
        //anim = GetComponentInChildren<Animator>();
        //上面这行语法正确，但是由于子物体最开始没激活，只能用第二种方法
        anim = signSprite.GetComponent<Animator>();
        playerInput = new PlayerInputControll();
        playerInput.Enable();
    }

    private void OnEnable()
    {
        InputSystem.onActionChange += OnActionChange;
        playerInput.Gameplay.Confirm.started += OnConfirm;
    }

    private void OnDisable()
    {
        canPress = false;
    }
    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled = canPress;
        signSprite.transform.localScale = playerTrans.localScale;
    }

    private void OnConfirm(InputAction.CallbackContext context)
    {
        if (canPress)
        {
            targetItem.TriggerAction();//触发互动，用统一的接口实现方法
            //GetComponent<AudioDefination>()?.PlayAudioClip();
        }
    }

    private void OnActionChange(object obj, InputActionChange actionChange)
    {
        if (actionChange == InputActionChange.ActionStarted)
        {
            /*obj为c#中最基本的类
            Debug.Log((((InputAction)obj).activeControl.device));
            当前激活设备
            var d = ((InputAction)obj).activeControl.device;
            switch (d.device)
            {
                case Keyboard:*/
                    anim.Play("KeyBoard");
                    /*break;
                case DualShockGamepad://应该用不到ps手柄
                    anim.Play("Ps");
                    break;
            }*/
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canPress = true;
            targetItem = other.GetComponent<IInteractable>();//获得接口类型
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPress = false;
    }
}
