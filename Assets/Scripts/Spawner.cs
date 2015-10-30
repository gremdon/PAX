using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{



    void Start()
    {
        StartCoroutine(Spawn());
    }

    /// <summary>
    /// Spawns prefabs based on information provided
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        ///Will continue untill stopAtLimit is true AND unit count is not less then limit
        while (!(stopAtLimit && limit <= units.Count) || limit < 0)
        {   ///Loops and removes all objects that have been destroyed outside this function
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] == null)
                {
                    units.RemoveAt(i);
                    i--;
                }
            }
            /// Will skip if waitAtLimit is true AND unit count is not less then limit
            if (!(waitAtLimit && limit <= units.Count) || limit < 0)
            {

                if (despawnAtLimit && limit <= units.Count && limit > 0)
                {
                    Destroy(units[0]);
                    units.RemoveAt(0);
                }

                units.Add((GameObject)Instantiate(prefab, transform.position, transform.rotation));

            }

            yield return new WaitForSeconds(timer);
        }
    }
    /// <summary>
    /// If true when limit is reached stops spawning.(stops running coroutine)
    /// </summary>
    [SerializeField]
    private bool stopAtLimit;
    /// <summary>
    /// If true when limit is reached will wait till a spot is clear.
    /// </summary>
    [SerializeField]
    private bool waitAtLimit;
    /// <summary>
    /// If true when limit is reached oldest gameobject will be destroyed.
    /// </summary>
    [SerializeField]
    private bool despawnAtLimit;
    /// <summary>
    /// Seconds per spawn.
    /// </summary>
    [SerializeField]
    private float timer;
    /// <summary>
    /// Prefab to be spawned
    /// </summary>
    [SerializeField]
    private GameObject prefab;
    /// <summary>
    /// Max number of spawned(If despawnAtLimit is true)
    /// </summary>
    [SerializeField]
    private int limit;
    /// <summary>
    /// storage and queue for each unit spawned(if despawnedAtLimit is true)
    /// </summary>


    private List<GameObject> units = new List<GameObject>();
}