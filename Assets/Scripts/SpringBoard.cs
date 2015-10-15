using UnityEngine;
using System.Collections;

public class SpringBoard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * power *
                -other.gameObject.GetComponent<Rigidbody>().velocity.y);
        }
    }

    public float power;
}
