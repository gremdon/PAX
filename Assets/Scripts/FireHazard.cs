using UnityEngine;
using System.Collections;

public class FireHazard : MonoBehaviour
{
    void Start ()
    {
	    Messenger.AddListener<GameObject>("HeatSink_Hit", OnHeatSinkHit);
	}

    void OnHeatSinkHit(GameObject go)
    {   
        if(go == gameObject)
        {
            if(_actionOnHeatSink == FireHazrdReaction.DIE)
            {
                Die();
            }

            if(_actionOnHeatSink == FireHazrdReaction.COOL)
            {
                Cool();
            }
        }
    }

    void Cool()
    {
        Messenger.Broadcast("Chilled", gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
        Messenger.RemoveListener<GameObject>("HeatSink_Hit", OnHeatSinkHit);
    }

    [SerializeField]
    private FireHazrdReaction _actionOnHeatSink;

}


enum FireHazrdReaction
{
    DIE,
    COOL
}