using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Happend the first frame the spawner exist
    /// </summary>
    void Start()
    {
        enableSpawn = false;
        Callback toggle = ToggleSpawn;
        Messenger.AddListener(name.ToLower(), toggle);
    }
    
    void ToggleSpawn()
    {
        enableSpawn = !enableSpawn;
    }

    /// <summary>
    /// Coroutine for spawning enemies forever,
    /// or until the spawner is destroyed.
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        m_spawnTimer = 0;   // Zeroes out the spawn timer

        if (entityToSpawn)                  // Makes sure there is an entityToSpawn
        {                                   // if so...
            while (enableSpawn)                 // As long as enableSpawn is true       
            {                                   // ...
                m_spawnTimer += Time.deltaTime;     // Increase the timer by deltaTime every frame
                                                    //
                if (m_spawnTimer >= spawnDelay)     // Check to see if the timer is greater than the predetermined delay
                {                                   // if so...
                    Instantiate(entityToSpawn,          // Spawn the entity
                                transform.position,     // at this position
                                transform.rotation);    // and rotation
                                                        //
                    m_spawnTimer = 0;                   // Reset the spawn timer
                }

                yield return null;
            }
        }
    }

    /// <summary>
    /// Timer.
    /// </summary>
    private float m_spawnTimer;

    /// <summary>
    /// Switch to turn the spawning on/off
    /// </summary>
    private bool m_enableSpawn;


    /// <summary>
    /// Getter and setter for toggling the enemy spawner
    /// </summary>
    public bool enableSpawn
    { 
        // "something" = enableSpawn
        get                            
        {
            return m_enableSpawn;       // "something" = m_enableSpawn
        }
        // enableSpawn = "something"
        set                             
        {                               
            m_enableSpawn = value;      // m_enableSpawn = "something"
            StartCoroutine(Spawn());    // Chack to see if the new value would start spawning
        }
    }

    /// <summary>
    /// The GameObject to be created by this spawner.
    /// </summary>
    public GameObject entityToSpawn;

    /// <summary>
    /// Time in seconds between spawns.
    /// </summary>
    public float spawnDelay;
}