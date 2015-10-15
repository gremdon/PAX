using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Slider health;
    [SerializeField]
    private Text weaponName;
    [SerializeField]
    private Text weaponAmmo;

    // Use this for initialization
    void Awake()
    {
        Messenger.AddListener<float, float>("HealthChange", HealthChange);
    }
    void HealthChange(float cur, float max)
    {
        health.maxValue = max;
        health.value = cur;
    }
}
