using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderChange : HudListener {

    protected override void DoSomething(string message)
    {
        GetComponent<Slider>().value--;
    }
}
