using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : Singleton<PlayerManager> {

    public GameObject Player1
    {
        get;
        private set;
    }
    public GameObject Player2
    {
        get;
        private set;
    }
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    protected override void Awake()
    {
        
        List<PlayerCharacterController> pcc = new List<PlayerCharacterController>(GameObject.FindObjectsOfType<PlayerCharacterController>());
        
        foreach(PlayerCharacterController p in pcc)
        {
            players.Add(p.gameObject);           
        }
        if(players[0] != null)
            Player1 = players[0];
        if(players[1] != null)
            Player2 = players[1];
    }
}
