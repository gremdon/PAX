using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
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
            rb.AddForce((transform.forward).normalized * speed);
        }
        float closingDistance = .5f;
        float distance = Vector3.Distance(transform.position, nxtPos);
        txt.text = distance.ToString();
        if ( distance < closingDistance ) //if i'm close
        {
            //get next pos and then turn
            SetNextPos();
        }

       // Debug.Log(nxtPos.magnitude);
       // Debug.Log(nxtPos);
       
        Debug.DrawLine(transform.position, nxtPos, Color.red);

        Debug.DrawLine(transform.position, transform.forward.normalized, Color.blue);

        Debug.Log(nxtPos.normalized);
        Debug.DrawLine(transform.position, Vector3.Normalize(transform.position - nxtPos), Color.black);
    }

    IEnumerator Turn()
    {
        float dot = Vector3.Dot(transform.forward, Vector3.Normalize(transform.position - nxtPos));
        
        while ( dot < .75f )
        {
            Debug.Log("dot is " + dot);
            transform.forward += (transform.forward + nxtPos) * Time.deltaTime;
            yield return null;
        }
        Debug.Log("done turning");
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

    float stuckTimer;
    float stuckDelay;

    Vector3 nxtPos;
    Vector3 origin;

    Rigidbody rb;

    public UnityEngine.UI.Text txt;
}
