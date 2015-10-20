using UnityEngine;
using System.Collections;

/// <summary>
/// Developed by: Quinton Baudion
/// 
/// Purpose: To be disabled and enabled from a Message.Broadcast
///       
///         gamobject will be added as a listener based on listenFor string. 
///         When the string is broadcasted this gameobject will ither be enabled
///         or disabled based on its current state.
///         ie. If its active it will be disabled or if its inactive it will be enabled. 
/// </summary>

public class EnableDisable : MonoBehaviour
{
    

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
    bool enabledOnStart;

    [SerializeField]
    protected string listeningFor;
}
