using UnityEngine;
using System.Collections;

public class SpringBoard : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * power);
        }
    }
    
    public float power;
}
