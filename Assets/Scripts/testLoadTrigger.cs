using UnityEngine;
using System.Collections;

public class testLoadTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
              FindObjectOfType<LevelLoader>().LoadLevelSection("testLevel");
        }
    }
}
