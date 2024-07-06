using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvetManager : MonoBehaviour
{

    Animator ani;

    bool canInput;

    public PlayerInputControll inputControl;
    

    private void Start()
    {
        inputControl = new PlayerInputControll();
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
                EventCenter.Instance.EventTrigger("ÇÐ»»×´Ì¬");
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("½øÈë");
        if(collision.tag == "Player")
        {
            canInput = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Àë¿ª");
        if (collision.tag == "Player")
        {
            canInput = false;
        }
    }
}
