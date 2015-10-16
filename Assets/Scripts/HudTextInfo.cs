using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudTextInfo : HudListener
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void DoSomething(string message)
    {
        GetComponent<Text>().text = message;
    }

}
