using UnityEngine;
using System.Collections;

public class BroadcastOnTrigger : MonoBehaviour
{
    public string message;
    public string argument;
    void OnTriggerEnter()
    {
        //col is the name of the gameobject this collider is attached for
        Messenger.Broadcast<string>(message, argument);
    }
}
