using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : IPointBase
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public override void OnPointExit()
    {
        base.OnPointExit();
        image.color = new Color(1f, 1, 1f);
        gameObject.transform.DOScale(1f, 0.2f);
    }


    public override void OnPointEnter()
    {
        base.OnPointEnter();
        image.color = new Color(0.85f, 0.85f, 0.85f);
    }


    public override void OnPointDown()
    {
        base.OnPointDown();
        image.color = new Color(0.85f, 0.85f, 0.85f);
        gameObject.transform.DOScale(0.9f, 0.2f);
        Application.Quit();
    }
}
