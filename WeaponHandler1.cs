using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler1 : MonoBehaviour
{
       [SerializeField] private GameObject weaponLogic;
    




    public void Start()
    {
        
    }
    public void EnableWeapon1()
    {
        weaponLogic.SetActive(true);
       
    }

    public void DisableWeapon1()
    {
        weaponLogic.SetActive(false);
      
    }
}
