using UnityEngine;
using System.Collections;

public class Obstacle : HealthStats
{
    protected override void OnDead()
    {
        Destroy(gameObject);
    }
}
