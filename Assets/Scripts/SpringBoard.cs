using UnityEngine;
using System.Collections;

public class SpringBoard : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != transform)
        {
            if (other.gameObject.GetComponent<Rigidbody>() && other.gameObject.GetComponent<Rigidbody>().velocity.y > 1)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * power * 500);
            }
        }
    }
    
    public float power;
}
