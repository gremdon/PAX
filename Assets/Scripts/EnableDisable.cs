using UnityEngine;
using System.Collections;

public class EnableDisable : MonoBehaviour
{
    [SerializeField]
    bool enabledOnStart;

    protected virtual void DoSomething()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    protected virtual void Awake()
    {
        Messenger.AddListener(listeningFor, DoSomething);

        if (enabledOnStart)
            return;
        DoSomething();
    }


    [SerializeField]
    protected string listeningFor;
}
