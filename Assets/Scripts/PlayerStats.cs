using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Slider health;
    [SerializeField]
    private List<Sprite> playerSprite = new List<Sprite>();

    // Use this for initialization
    void Awake()
    {
        Messenger.AddListener<float, float>("HealthChange", HealthChange);
        //Messenger.AddListener<string, int, int>("Weapon Changed", WeaponInfo);
        //Messenger.AddListener<int, int>("Ammo Changed", AmmoCount);
    }
    //void WeaponInfo(string name, int cur, int max)
    //{
    //    weaponName.text = name;
    //    weaponAmmo.text = cur.ToString() + '/' + max.ToString();
    //}
    //void AmmoCount(int cur, int max)
    //{
    //    weaponAmmo.text = cur.ToString() + '/' + max.ToString();
    //}
    void HealthChange(float cur, float max)
    {

        health.maxValue = max;
        health.value = cur;
        
            //print(child.ToString());
            //child.gameObject.GetComponentInChildren<Slider>().maxValue = max;
            //child.gameObject.GetComponentInChildren<Slider>().value = cur;        
    }
}