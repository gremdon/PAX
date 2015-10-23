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
        Messenger.Broadcast("playerdied", this);
    }

    public void OnEnable()
    {
        Messenger.AddListener<string>("takedamage", TakeDamage);
    }
}
