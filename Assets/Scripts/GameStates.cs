using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour
{
    void Pause()
    {
        Time.timeScale = 0;
    }

    void Unpause()
    {
        Time.timeScale = 1;
    }
}
