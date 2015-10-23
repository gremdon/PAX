using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine("TakeDamage", other);
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine("TakeDamage");
    }

    IEnumerator TakeDamage(Collider other)
    {
        while (true)
        {
            Messenger.Broadcast("takedamage", other.name);
            yield return new WaitForSeconds(timer);
        }
    }

    [SerializeField]
    float timer = 1;
}