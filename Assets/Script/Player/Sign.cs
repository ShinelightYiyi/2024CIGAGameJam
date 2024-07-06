using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;


/// <summary>
/// ��ʾ�Ƿ�ɽ���
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
        //���������﷨��ȷ�����������������ʼû���ֻ���õڶ��ַ���
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
            targetItem.TriggerAction();//������������ͳһ�Ľӿ�ʵ�ַ���
            //GetComponent<AudioDefination>()?.PlayAudioClip();
        }
    }

    private void OnActionChange(object obj, InputActionChange actionChange)
    {
        if (actionChange == InputActionChange.ActionStarted)
        {
            /*objΪc#�����������
            Debug.Log((((InputAction)obj).activeControl.device));
            ��ǰ�����豸
            var d = ((InputAction)obj).activeControl.device;
            switch (d.device)
            {
                case Keyboard:*/
                    anim.Play("KeyBoard");
                    /*break;
                case DualShockGamepad://Ӧ���ò���ps�ֱ�
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
            targetItem = other.GetComponent<IInteractable>();//��ýӿ�����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPress = false;
    }
}
