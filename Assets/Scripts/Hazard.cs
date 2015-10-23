using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast("hazard" + other.name);
        print("hazard" + other.name);
    }
}