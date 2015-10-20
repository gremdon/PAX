using UnityEngine;
using System.Collections;


/// <summary>
/// Developed by: Quinton Baudoin
/// 
/// Purpose: To act as a Lock or Key.
///          When a key is given to a gameobject's collider (By trigger) it is checked for id.
///          If id is correct the DoSomething function is called on the Key.
///          If id is incorrect the gamobject is moved away from the lock;
/// </summary>

public class LockKey : MonoBehaviour
{

    /// <summary>
    /// Compares two LockKey's keyID string
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    static public bool CompareId(LockKey a, LockKey b)
    {
        if (a.keyId == b.keyId)
            return true;
        else return false;
    }

    /// <summary>
    /// Currently just calls a Message.Broadcast
    /// </summary>
    private void DoSomething()
    {
        print(broadcastMessage);
        Messenger.Broadcast(broadcastMessage);


    }
    //private void UnDoSomething()
    //{
    //    if (isLock && broadcastMessage != null)
    //    {
    //        Messenger.Broadcast(broadcastMessage);
    //    }
    //}
    /// <summary>
    /// If gameobject has no parent it will parent it to the player that publishes action button
    /// if gamobject has a parent it will unparent it
    /// </summary>
    private void PickedUp()
    {
        if (gameObject.transform.parent == null)
        {
            gameObject.transform.SetParent(player.transform);
            gameObject.transform.localPosition = Vector3.zero;
        }
        else if (gameObject.transform.parent != null)
            gameObject.transform.SetParent(null);

    }
    void OnTriggerStay(Collider c)
    {
        if (isLock)
            if (c.GetComponent<LockKey>() && !CompareId(this, c.GetComponent<LockKey>()) && c.GetComponent<Transform>().parent == null)
            {
                Vector3 temp = Vector3.zero;
                temp.x = Random.Range(-2, 2) * GetComponent<BoxCollider>().size.x;
                temp.z = Random.Range(-2, 2) * GetComponent<BoxCollider>().size.x;
                c.GetComponent<Transform>().position = temp;
            }
    }

    void OnTriggerEnter(Collider c)
    {


        if (c.GetComponent<LockKey>() && isLock && !c.GetComponent<LockKey>().isLock)
        {
            if (CompareId(this, c.GetComponent<LockKey>()))
                c.GetComponent<LockKey>().DoSomething();
        }
        else if (c.GetComponent<InputSystem>() && !isLock)
        {
            if (c.GetComponent<LockKey>() && !isLock)
                return;

            player = c.gameObject;
            Messenger.AddListener("e", PickedUp);
        }

    }
    void OnTriggerExit(Collider c)
    {
        if (c.GetComponent<LockKey>() && isLock && !c.GetComponent<LockKey>().isLock)
        {
            if (CompareId(this, c.GetComponent<LockKey>()))
                c.GetComponent<LockKey>().DoSomething();
        }
        else if (c.GetComponent<InputSystem>() && !isLock)
        {
            if (c.GetComponent<LockKey>() && !isLock)
                return;
            player = null;
            Messenger.RemoveListener("e", PickedUp);

        }
    }

    /// <summary>
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
    private string broadcastMessage = null;
    /// <summary>
    /// Getter for key _keyId
    /// </summary>
    public string keyId
    {
        get { return _keyId; }
    }

    GameObject player = null;
}
