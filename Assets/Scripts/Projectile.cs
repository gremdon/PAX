using UnityEngine;
using System.Collections;

public class Projectile : HealthStats
{
    

    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float Timer = 100;

    bool alive = true;
    protected override void OnDead()
    {
        base.OnDead();
        Destroy(gameObject);
    }
    // Use this for initialization

    // Update is called once per frame
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>())
          GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        
        else StartCoroutine("Forward");
    }

    IEnumerator Forward()
    {        
        transform.position += transform.forward * speed;

        yield return null;
    }

    void Update()
    {
       
        Timer -= Time.deltaTime;
        if (Timer < 0)
        OnCollisionEnter();
    }

    void OnCollisionEnter()
    {
        if (!gameObject.GetComponent<Rigidbody>())
            StopCoroutine("Forward");

        Destroy(gameObject);
    }


}
