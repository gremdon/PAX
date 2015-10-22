using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast(other.name, "HAZARD");
    }
}
