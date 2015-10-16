using UnityEngine;
using System.Collections;

public class HudPortraits : HudListener
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void DoSomething(string message)
    {
        if(name == message)
        {
            gameObject.SetActive(true);
            return;
        }

        gameObject.SetActive(false);
    }
}
