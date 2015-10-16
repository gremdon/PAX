using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(canPress)
        {
            Messenger.Broadcast(messageToPublish.ToLower());
            canPress = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(setDirty)
        {
            canPress = true;
        }
    }

    private bool canPress = true;
    public string messageToPublish;
    public bool setDirty = false;
}