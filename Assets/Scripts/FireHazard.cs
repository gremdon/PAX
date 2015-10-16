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
            Debug.Log(gameObject.name + ": I'm Cool now");
            if(_actionOnHeatSink == FireHazrdReaction.DIE)
            {
                print("Heatsink Hit received by " + gameObject.name);
                Die();
            }
        }
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