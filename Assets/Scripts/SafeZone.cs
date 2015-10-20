using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
