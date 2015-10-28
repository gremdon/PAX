using UnityEngine;
using System.Collections;

public class RigidWander : MonoBehaviour
{
    void Start()
    {
        origin = transform.position;
        rb = GetComponent<Rigidbody>();
        SetNextPos();
    }

    void Update()
    {
        if (canMove)
        {
            rb.AddForce((nxtPos - transform.position).normalized * speed);
        }

        if(Vector3.Distance(transform.position, nxtPos) < 1f)
        {
            SetNextPos();
        }
    }

    IEnumerator Turn()
    {
        while(Vector3.Distance(transform.forward, nxtPos.normalized) > 1)
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(nxtPos), Time.deltaTime);
            yield return null;
        }
        canMove = true;
    }

    void SetNextPos()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        Vector2 t = (Random.insideUnitCircle * range);
        nxtPos = new Vector3(t.x, 0, t.y) + (origin - transform.position);
        StartCoroutine("Turn");
    }

    public float speed;
    public float range;

    bool canMove;
    Vector3 nxtPos;
    Vector3 origin;
    Rigidbody rb;
}
