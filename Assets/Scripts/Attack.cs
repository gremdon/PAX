using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (canAttack)
        {
            StartCoroutine("TakeDamage", other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine("TakeDamage");
    }

    IEnumerator TakeDamage(Collider other)
    {
        while (other)
        {
            Messenger.Broadcast("takedamage", other.name);
            yield return new WaitForSeconds(timer);
        }
    }

    [SerializeField]
    float timer = 1;

    public bool canAttack = true;
}

/// Eric Mouledoux