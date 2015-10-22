using UnityEngine;
using System.Collections;

public class TeleporterPads : MonoBehaviour
{
    //GameObject that is used to refrence destination we want the object that enters the teleporter pad to
    //be teleported to
    //You manually assign the linked locatons in the inpector
    public GameObject linker;

    //When an object enters the the trigger it teleports it to the linker
    //location
    void OnTriggerEnter(Collider c)
    {
        GameObject a = c.gameObject as GameObject;
        a.transform.position = linker.transform.position;
    }
}
