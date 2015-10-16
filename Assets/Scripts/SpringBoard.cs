using UnityEngine;
using System.Collections;

/// <summary>
/// Spring board environmental
/// </summary>
public class SpringBoard : MonoBehaviour
{
    void OnTriggerExit(Collider other)                              // Once any entity has left the springboard    
    {                                                               //
        if (other.transform.parent != transform)                        // Chect to makesure it's not the spring board itself.
        {                                                               // if so...
            if (other.gameObject.GetComponent<Rigidbody>() &&               // Check to make sure it has a Rigidbody
                other.gameObject.GetComponent<Rigidbody>().velocity.y > 1)  // and is moving up and not just forward or sidways.
            {                                                               // if so...
                other.gameObject.GetComponent<Rigidbody>().                     // Get the Rigidbody of the entity
                    AddForce(transform.up * power * m_minimumPower);            // and add force equal to the board's reletive up at a force of (minimumPower x power)
            }
        }
    }
    
    /// <summary>
    /// "Springiness" of the board
    /// </summary>
    public float power;

    /// <summary>
    /// Minimum power for a noticable jump height increase
    /// </summary>
    private const float m_minimumPower = 500;
}
