using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrhougGapManager : MonoBehaviour
{
    private GameObject player;

    public Transform P1, P2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EventCenter.Instance.AddEventListener("��P1����", () => TroughP1());
        EventCenter.Instance.AddEventListener("��P2����", () => TroughP2());
    }

    private void TroughP1()
    {
        EventCenter.Instance.EventTrigger("����ʼ");
        player.transform.DOMove(P1.position, 0.1f).OnComplete(() => player.transform.DOMove(P2.position, 0.5f).OnComplete(() => EventCenter.Instance.EventTrigger("�������")));
    }

    private void TroughP2()
    {
        EventCenter.Instance.EventTrigger("����ʼ");
        player.transform.DOMove(P1.position, 0.5f).OnComplete(() => EventCenter.Instance.EventTrigger("�������"));
    }
}
