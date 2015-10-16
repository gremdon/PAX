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
        Messenger.AddListener<string, int, int>("Weapon Changed",WeaponInfo);
        Messenger.AddListener<int, int>("Ammo Changed", AmmoCount);
    }
    void WeaponInfo(string name, int cur, int max)
    {
        weaponName.text = name;
        weaponAmmo.text = cur.ToString() + '/' + max.ToString();
    }
    void AmmoCount(int cur, int max)
    {
        weaponAmmo.text = cur.ToString() + '/' + max.ToString();
    }
    void HealthChange(float cur, float max)
    {
        health.maxValue = max;
        health.value = cur;
    }
}
