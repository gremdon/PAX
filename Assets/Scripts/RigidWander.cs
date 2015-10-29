using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class RigidWander : MonoBehaviour
{
    void Start()
    {
        origin = transform.position;
        rb = GetComponent<Rigidbody>();
        SetNextPosition();
    }
    Vector3 f;
    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce((nxtPos - transform.position).normalized * 100 * speed);

        if(Vector3.Distance(transform.position, nxtPos) < 1f)
            SetNextPosition();
        

        Debug.DrawLine(transform.position, nxtPos, Color.red);
    }

    void SetNextPosition()
    {
        lstPos = nxtPos;
        Vector2 t = (Random.insideUnitCircle * range);
        nxtPos = new Vector3(t.x, 0, t.y) + origin;
    }

    public float speed;
    public float range;

    public Vector3 nxtPos = new Vector3();

    bool canMove;

    Vector3 lstPos = new Vector3();
    Vector3 origin = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;
}
