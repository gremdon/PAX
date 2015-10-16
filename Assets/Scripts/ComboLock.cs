using UnityEngine;
using System.Collections;

public class ComboLock : MonoBehaviour
{
    //Correct Combo to the lock
    string LockCombo;
    //Objects that represent a value the user will input as a combo to the lock
    public GameObject[] Keys;
    public int[] value; //Value assigned to each key

    ComboLock(string combo)
    {
        combo = LockCombo;
    }

    void UserInput(string s)
    {
        
    }
}
