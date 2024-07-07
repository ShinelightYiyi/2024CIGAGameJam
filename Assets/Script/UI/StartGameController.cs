using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : IPointBase
{
    public override void OnPointDown()
    {
        base.OnPointDown();
        EventCenter.Instance.EventTrigger<string>("обр╩╧ь", "Level1");
    }
}
