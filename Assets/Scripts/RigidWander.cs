using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class RigidWander : MonoBehaviour
{
    void Start()
    {
        target = null;
        origin = transform.position;
        rb = GetComponent<Rigidbody>();
        SetNextPosition();
    }

    void Update()
    {
        rb.velocity = Vector3.zero;

        if (target)
        {
            rb.AddForce((target.transform.position - transform.position).normalized * speedConst * speed * 2f);
            Debug.DrawLine(transform.position, target.transform.position, Color.red);
        }
        else
        {
            rb.AddForce((nxtPos - transform.position).normalized * speedConst * speed);

            Debug.DrawLine(transform.position, nxtPos, Color.red);
        }

        if (Vector3.Distance(transform.position, nxtPos) < 1f)
        {
            SetNextPosition();
        }
    }

    void SetNextPosition()
    {
        lstPos = nxtPos;
        Vector2 t = (Random.insideUnitCircle * range);
        nxtPos = new Vector3(t.x, 0, t.y) + origin;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<UnityChanControlScriptWithRgidBody>() &&  target == null)
            target = other.gameObject;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
            target = null;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>())
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public float speed;
    public float range;

    public GameObject target;

    bool canMove;

    const float speedConst = 100;

    Vector3 nxtPos = new Vector3();
    Vector3 lstPos = new Vector3();
    Vector3 origin = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;
}
