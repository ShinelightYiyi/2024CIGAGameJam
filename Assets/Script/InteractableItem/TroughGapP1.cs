using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroughGapP1 : MonoBehaviour
{
    bool isEnter;
    bool isCat;

    [SerializeField] GameObject go;

    private void Start()
    {
        isCat = false;
       EventCenter.Instance.AddEventListener("«–ªª◊¥Ã¨", () => ChangeP1Condition());
    }

    private void Update()
    {
        
        if(isEnter)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                EventCenter.Instance.EventTrigger("¥”P1¥©ÀÛ");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if (collision.tag == "Player")
        {
            if (isCat)
            {
                Debug.LogWarning("Ω¯»ÎP1");
                go.SetActive(true);
                isEnter = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (isCat)
            {
                isEnter = false;
                go.SetActive(false);
            }
        }
    }

    private void ChangeP1Condition()
    {
        isCat = !isCat;
    }
}
