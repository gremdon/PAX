using UnityEngine;

public class InputSystem : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))        
            Messenger.Broadcast("e");        
        //else if (Input.GetKeyDown(KeyCode.Z))
        //    Messenger.Broadcast("movement", "prone");
        //else if (Input.GetKeyDown(KeyCode.W))
        //    Messenger.Broadcast("movement", "idle");

    }

}



