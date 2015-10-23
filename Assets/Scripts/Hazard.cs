using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast("takedamage", other.name);
        print("takedamage" + other.name);
    }
}