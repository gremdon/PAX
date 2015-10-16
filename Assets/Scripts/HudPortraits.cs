using UnityEngine;
using System.Collections;

public class HudPortraits : HudListener
{
    protected override void Awake()
    {
        gameObject.SetActive(false);
        base.Awake();
    }
    protected override void DoSomething(string message)
    {
        if(name == message.ToString())
        {
            gameObject.SetActive(true);
            return;
        }

        gameObject.SetActive(false);
    }
}
