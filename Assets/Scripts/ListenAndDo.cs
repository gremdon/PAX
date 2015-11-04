using UnityEngine;
using System.Collections;

public class ListenAndDo : HudListener {
    public string listenFor;
    protected override void DoSomething(string message)
    {
        if (message == listenFor)
            GetComponent<AudioSource>().Play();
    }
}
