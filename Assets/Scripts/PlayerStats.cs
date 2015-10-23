/// <summary>
/// Developed by: Quinton "Kiro" Baudoin.
/// 
/// Purpose: To act as a health counter.
/// 
/// Usage: Attach to desired gameobject and use the Messanger System
///         to broadcast "takedamage", with name of gameobject and this
///         script will check to see if it got hit and then reduce health.
///         When health hits 0 or less "playerdied" with name of gameobject this is
///         attached to.
/// 
/// </summary>
///////////////////////////////////


using UnityEngine;
using System.Collections;



public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int _health;
    public int health
    {
        get { return _health; }
        private set
        {          
           _health = value;

            if (health < 0)
                OnDead();
        }

     }



    public void TakeDamage(string message)
    {
        if (message == name)
        { health--; }
    }

    private void OnDead()
    {
        Messenger.Broadcast("playerdied", name);
    }

    public void OnEnable()
    {
        Messenger.AddListener<string>("takedamage", TakeDamage);
    }
}
