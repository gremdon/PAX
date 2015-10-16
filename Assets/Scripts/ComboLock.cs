using UnityEngine;
using System.Collections;

public class ComboLock : MonoBehaviour
{
    //Correct Combo to the lock
    public string LockCombo;
    //Objects that represent a value the user will input as a combo to the lock
    int j = 0;
    public int i = 0;
    int test = 0;
    public string[] input;
    string[] value = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public GameObject[] keys;

    void Awake()
    {
        Callback<string> stuff = UserInput;
        Messenger.AddListener<string>(value[i], UserInput);
        Debug.Log(value[i]);
    }

    void Start()
    {

    }

    void UserInput(string s)
    {
       input[test] = s;
        test++;
    }

    [ContextMenu("Add Values")]
    void SetKeyValues()
    {
        foreach(GameObject g in keys)
        {
            g.GetComponent<PressurePlate>().messageToPublish = value[i];
            i += 1;
        }
    }
}


/*
//dylans logic
    messenger.addlistener<int>("walked on combo platform, handleWalkedOn);

    void handleWalkedOn(int id)
    {
        debug.log("user walked on " + id);


    }

    */


    /*
    platform broadcast

    void OnTriggerEnter()
    {

    messenger.broadcast<int>("walked on combo platform", this.id);
    }
    */