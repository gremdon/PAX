using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class EnemyWander : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener<string>("entitydied", Die);
    }

    void Start()
    {
        target = null;
        origin = new Vector2(transform.position.x, transform.position.z);
        rb = GetComponent<Rigidbody>();
        //SetNextPosition();
    }

    IEnumerator Persue()
    {
        RaycastHit hit;

        while (target)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);

            float dist = Vector3.Distance(transform.position, target.transform.position);

            Physics.Raycast(transform.position, target.transform.position, out hit, dist);

            print(hit.transform.gameObject);

            if (hit.transform.gameObject == target)
            {
                Vector3 targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
                Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
                Vector3 heading = Vector3.Normalize(targetPos - currentPos);
                rb.AddForce(heading * speedConst * speed);
            }

            Debug.DrawLine(transform.position, target.transform.position, Color.red);
            yield return null;
        }
        //else
        //{
        //    Vector3 targetPos = new Vector3(nxtPos.x, 0, nxtPos.z);
        //    Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
        //    Vector3 heading = Vector3.Normalize(targetPos - currentPos);
        //    rb.AddForce(heading * speedConst * speed);

        //    Debug.DrawLine(transform.position, nxtPos, Color.red);

        //    if (Vector3.Distance(transform.position, nxtPos) < 1f)
        //    {
        //        SetNextPosition();
        //    }
        //}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerCharacterController>() && target == null)
        {
            target = other.gameObject;
            StartCoroutine(Persue());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
            target = null;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<PlayerCharacterController>())
        {
            Messenger.Broadcast("takedamage", name);
        }
    }

    void Die(string a)
    {
        if (a == name)
        {
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    void SetNextPosition()
    {
        Vector2 t;
        float dist;

        t = (Random.insideUnitCircle * range) + origin;
        nxtPos = new Vector3(t.x, transform.position.y, t.y);
        dist = Vector3.Distance(transform.position, nxtPos);

        if(Physics.Raycast(transform.position, nxtPos, dist))
        {
            SetNextPosition();
        }
    }

    public float speed;
    public float range;

    public GameObject target;

    const float speedConst = 100;

    Vector2 origin = new Vector2();
    Vector3 nxtPos = new Vector3();
    Vector3 forward = new Vector3();

    Rigidbody rb;
}
