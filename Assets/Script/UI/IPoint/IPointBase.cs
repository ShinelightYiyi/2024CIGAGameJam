using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class IPointBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    #region ʵ�ֽӿ�
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointDown();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointExit();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointUp();
    }
    #endregion

    public virtual void OnPointDown()
    {

    }

    public virtual void OnPointUp()
    {

    }

    public virtual void OnPointEnter()
    {

    }

    public virtual void OnPointExit()
    {

    }



}
