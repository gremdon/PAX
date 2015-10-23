using UnityEngine;
using System.Collections;

public class BroadcastOnTrigger : MonoBehaviour {
    public string message;
    void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast<string>(message, col.name);
    }
}
