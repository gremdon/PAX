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
            if (value > 0)
            {
                _health = value;
            }
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
        Messenger.AddListener<string>("hazard", TakeDamage);
    }
}
