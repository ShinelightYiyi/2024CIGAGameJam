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
        EventCenter.Instance.AddEventListener("从P1穿梭", () => TroughP1());
        EventCenter.Instance.AddEventListener("从P2穿梭", () => TroughP2());
    }

    private void TroughP1()
    {
        EventCenter.Instance.EventTrigger("穿梭开始");
        player.transform.DOMove(P1.position, 0.1f).OnComplete(() => player.transform.DOMove(P2.position, 0.5f).OnComplete(() => EventCenter.Instance.EventTrigger("穿梭结束")));
    }

    private void TroughP2()
    {
        EventCenter.Instance.EventTrigger("穿梭开始");
        player.transform.DOMove(P1.position, 0.5f).OnComplete(() => EventCenter.Instance.EventTrigger("穿梭结束"));
    }
}
