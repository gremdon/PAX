using UnityEngine;
using System.Collections;

public class HPGauge : HudListener
{
    // Update is called once per frame
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void DoSomething(string message)
    {
        if (message == "hp")
        {
            Debug.Log("message");
            GetComponent<UnityEngine.UI.Slider>().value -= 1;
        }
    }
}
