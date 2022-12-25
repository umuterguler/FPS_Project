using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmunitionManager : MonoBehaviour
{ 
    public static AmmunitionManager instance;
    public AmmunitionUi ammunitionUi;
    
    private Dictionary<AmmunitionTypes, int> ammunitionCounts = new Dictionary<AmmunitionTypes, int>();
    
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

    private void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(AmmunitionTypes)).Length; i++)
        {
            ammunitionCounts.Add((AmmunitionTypes)i, 0);
        }
    }

    public void AddAmmunition(int value , AmmunitionTypes ammunitionTypes)
    {
        ammunitionCounts[ammunitionTypes] += value;
        ammunitionUi.UpdatedAmmunitionCountUi(ammunitionCounts[ammunitionTypes]);
    }

    public int GetAmmoCount(AmmunitionTypes ammunitionTypes)
    {
        return ammunitionCounts[ammunitionTypes];
    }
    
    public bool ConsumeAmmo(AmmunitionTypes ammunitionTypes)
    {
        if (ammunitionCounts[ammunitionTypes] > 0)
        {
            ammunitionCounts[ammunitionTypes]--;
            ammunitionUi.UpdatedAmmunitionCountUi(ammunitionCounts[ammunitionTypes]);        
            return true;
        }
        else
        {
            return false;
        }
    }
}
