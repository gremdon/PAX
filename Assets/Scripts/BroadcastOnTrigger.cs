using UnityEngine;
using System.Collections;

public class BroadcastOnTrigger : MonoBehaviour {
    public string message;
    void OnTriggerEnter(Collider col)
    {
        //col is the name of the gameobject this collider is attached for
        Messenger.Broadcast<string>(message, col.name);
    }
}
