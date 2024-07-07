using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvetManager : MonoBehaviour
{

    Animator ani;

    bool canInput;

    [SerializeField] GameObject inputGo;


    

    private void Start()
    {

        ani = GetComponent<Animator>();
        canInput = false;
    }


    private void Update()
    {
        if(canInput)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ani.SetTrigger("isInput");
                EventCenter.Instance.EventTrigger("�л�״̬");
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����");
        if(collision.tag == "Player")
        {
            canInput = true;
            inputGo.SetActive(true);
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�뿪");
        if (collision.tag == "Player")
        {
            canInput = false;
            inputGo.SetActive(false);
        }
    }
}
