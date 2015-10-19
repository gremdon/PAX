using UnityEngine;
using System.Collections;

public class LockKey : MonoBehaviour
{/// <summary>
/// Sets Weather the the object is a lock or a key
/// lock == true
/// key == false
/// </summary>
    [SerializeField]
    bool isLock;
    /// <summary>
    /// Is the string id for the lock/key
    /// A lock will only be triggered if a key matching its id is withitn its trigger collider
    /// </summary>
    [SerializeField]
    private string _keyId;
    /// <summary>
    /// message that will be broadcasted if a lock has been triggered.
    /// </summary>
    [SerializeField]
    private string broadcastMessage =  null;
    /// <summary>
    /// Getter for key _keyId
    /// </summary>
    public string keyId
    {
        get { return _keyId; }
    }

    static public bool CompareId(LockKey a, LockKey b)
    {
        if (a.keyId == b.keyId)
            return true;
        else return false;
    }

    //Publishes a broadcast based on the message passed in
    private void DoSomething()
    {
        if (isLock)
        {
            Messenger.Broadcast(broadcastMessage);
        }
    }
    private void UnDoSomething()
    {
        if (isLock && broadcastMessage != null)
        {
            Messenger.Broadcast(broadcastMessage);
        }
    }

    void OnTriggerEnter(Collider c)
    {
       
        
        if(c.GetComponent<LockKey>() && isLock && !c.GetComponent<LockKey>().isLock)
        {
            if (CompareId(this, c.GetComponent<LockKey>()))
                DoSomething();
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.GetComponent<LockKey>() && isLock && !c.GetComponent<LockKey>().isLock)
        {
            if (CompareId(this, c.GetComponent<LockKey>()))
                UnDoSomething();
        }
    }
   

}
