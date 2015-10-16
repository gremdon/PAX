using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatforms : MonoBehaviour
{
    public float m_speed;
    Vector3 InitialPos;
    public Vector3 TargetPosition;

    [ContextMenu("MoveObj")]
    public void setLocation()
    {
        InitialPos = gameObject.transform.position;
        StartCoroutine(MoveObjects());

    }

    IEnumerator MoveObjects()
    {
        while(Vector3.Distance(gameObject.transform.position, TargetPosition) > 1.0f)
        {
            gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position, TargetPosition, m_speed);
            yield return null;
        }
        TargetPosition = InitialPos;
        yield return new WaitForSeconds(1f);
        StopCoroutine(MoveObjects());
    }
}
