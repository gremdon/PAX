using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class CamMultiFollowTarget : MonoBehaviour
{
    Transform player1, player2;
    int playerCount;
    

    void Start()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = players.Length;
        for(int i = 0; i < players.Length; ++i)
        {
            switch(i)
            {
                case 0:
                    {
                        player1 = players[i].transform;
                    }
                    break;
                case 1:
                    {
                        player2 = players[i].transform;
                    }
                    break;
            }
        }

    }

    void Update()
    {
        transform.position = (player1.position + player2.position) / playerCount;
    }

}
