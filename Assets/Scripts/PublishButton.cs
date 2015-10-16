using UnityEngine;
using System.Collections;

public class PublishButton : MonoBehaviour
{
    [SerializeField]
    string arg;
    [SerializeField]
    string message;
    public void Publish()
    {
        Messenger.Broadcast(message, arg);
    }

}
