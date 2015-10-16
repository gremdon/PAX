using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatforms : MonoBehaviour
{
    public float m_speed;
    Vector3 InitialPos;
    public Vector3 TargetPosition;

    IEnumerator MoveObjects()
    {
        while(Vector3.Distance(gameObject.transform.position, TargetPosition) > 1.0f)
        {
            yield return null;
        }
    }
}
