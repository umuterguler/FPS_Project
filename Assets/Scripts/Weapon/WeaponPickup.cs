using UnityEngine;

public class WeaponPickup : MonoBehaviour , ILootable
{
    [SerializeField] private Weapon weapon;

    public void OnLookStarted()
    {
        Debug.Log($"Started Looking at {weapon.weaponName}");
    }

    public void OnLookInteracted()
    {
        WeaponHandler.instance.PickUpGun(weapon);
        Destroy(gameObject);
    }

    public void OnLookStopped()
    {
        Debug.Log($"Started Looking at {weapon.weaponName}");
    }
}
