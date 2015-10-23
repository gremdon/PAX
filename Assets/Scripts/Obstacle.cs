using UnityEngine;
using System.Collections;

public class Obstacle : HealthStats
{
    protected override void OnDead()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
/// Eric Mouledoux