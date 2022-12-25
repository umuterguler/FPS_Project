using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
// ReSharper disable All

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;
    
    private GameObject currentWeaponPrefab;
    public Weapon currentWeapon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(this);
        }
    }
    
    public void PickUpGun(Weapon weapon)
    {
        if (currentWeapon != null)
        {
            Instantiate(currentWeapon.weaponPickup, transform.position + transform.forward, Quaternion.identity);
            Destroy(currentWeaponPrefab);
        }
        currentWeapon = weapon;
        currentWeaponPrefab = Instantiate(weapon.gameObject, transform);
        
        AmmunitionManager.instance.ammunitionUi.UpdatedAmmunitiontTypeUi(currentWeapon);
    } 
    
    
}
