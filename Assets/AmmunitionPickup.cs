using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour , ILootable
{
    [SerializeField] private int ammunitionCount;
    [SerializeField] private AmmunitionTypes ammunitionType;

    public void OnLookStarted()
    {
        Debug.Log($"Started Looking At {ammunitionType}");
    }

    public void OnLookInteracted()
    {
        AmmunitionManager.instance.AddAmmunition(ammunitionCount, ammunitionType);
        Destroy(gameObject);
    }

    public void OnLookStopped()
    {
        Debug.Log($"Stopped Looking At {ammunitionType}");
    }
}
