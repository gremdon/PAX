using UnityEngine;
using System.Collections;

public class BroadcastOnTrigger : MonoBehaviour {
    public string message;
    void OnTriggerEnter(Collider col)
    {
        //col is the name of the object that enters the trigger
        Messenger.Broadcast<string, string>(message, col.name,this.name);
    }
}
