using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPGauge : HudListener
{
    [SerializeField]
    protected string listeningForB;
    // Update is called once per frame
    protected override void Awake()
    {
        Messenger.AddListener<int, int>(listeningFor, DoSomething);
        Messenger.AddListener<int>(listeningForB, DoSomething);
    }

    protected override void DoSomething(int msga, int msgb)
    {
        GetComponent<Slider>().maxValue = msgb;
        GetComponent<Slider>().value = msga;
    }
    protected override void DoSomething(int message)
    {
        GetComponent<Slider>().value = message;
    }
}
