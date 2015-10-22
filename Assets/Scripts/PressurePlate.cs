using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(canPress)
        {
            NotifySubs();
            canPress = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (setDirty)
        {
            canPress = true;
        }
    }

    void NotifySubs()
    {
        if (stringArgument1 == string.Empty &&
            stringArgument2 == string.Empty &&
            stringArgument3 == string.Empty)
        {
            Messenger.Broadcast(messageToPublish.ToLower());
        }
        else if (stringArgument2 == string.Empty && stringArgument3 == string.Empty)
        {
            Messenger.Broadcast(messageToPublish.ToLower(), stringArgument1);
        }
        else if (stringArgument3 == string.Empty)
        {
            Messenger.Broadcast(messageToPublish.ToLower(), stringArgument1, stringArgument2);
        }
        else if (stringArgument1 != string.Empty &&
                 stringArgument2 != string.Empty &&
                 stringArgument3 !=string.Empty)
        {
            Messenger.Broadcast(messageToPublish.ToLower(), stringArgument1, stringArgument2, stringArgument3);
        }
        else
        {
            print("Invalid Arguments");
        }
    }

    private bool canPress = true;
    public string messageToPublish;

    public string stringArgument1 = string.Empty;
    public string stringArgument2 = string.Empty;
    public string stringArgument3 = string.Empty;

    public bool setDirty = false;
}

/// Eric Mouledoux