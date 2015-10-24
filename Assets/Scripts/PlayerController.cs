using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerController : MonoBehaviour
{
    private PlayerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
    float h;
    float v;
    bool crouch;
    float speed;
    bool running = false;
    void Awake()
    {
        Messenger.AddListener<string>(gameObject.name + ":j", PlayerJump);
        Messenger.AddListener<string>(gameObject.name + ":s", PlayerSpecial);
        Messenger.AddListener<string>(gameObject.name + ":a", PlayerAttack);
        Messenger.AddListener<string>(gameObject.name + ":h", MoveHorizontal);
        Messenger.AddListener<string>(gameObject.name + ":v", MoveVertical);
        Messenger.AddListener<string>(gameObject.name + ":r", PlayerRun);
    }

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<PlayerCharacter>();

    }

    #region Events
    void MoveHorizontal(string a)
    {
        h = CrossPlatformInputManager.GetAxis(gameObject.name + ":" + a);
    }

    void MoveVertical(string a)
    {
        v = CrossPlatformInputManager.GetAxis(gameObject.name + ":" + a);
    }

    void PlayerJump(string a)
    {
        if(!m_Jump)
            m_Jump = CrossPlatformInputManager.GetButton(gameObject.name + ":" + a);
    }

    void PlayerRun(string a)
    {
        running = true;
    }

    void PlayerAttack(string a)
    {
        Debug.Log(a + " Attack");
    }

    void PlayerSpecial(string a)
    {
        Debug.Log(a + " Special");
    }
    #endregion

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        if (!running)
        {
            m_Move *= 0.75f;
        }


        // pass all parameters to the character control script
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        running = false;
    }
}
