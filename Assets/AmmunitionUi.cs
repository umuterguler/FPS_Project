 using System;
 using System.Collections;
using System.Collections.Generic;
 using TMPro;
 using UnityEngine;

public class AmmunitionUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammunitionTypeText;
    [SerializeField] private TextMeshProUGUI ammunitionCountText;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void UpdatedAmmunitiontTypeUi(Weapon weapon)
    {
        if (weapon == null)
        {
            canvasGroup.alpha = 0;
        }
        canvasGroup.alpha = 1;

        UpdatedAmmunitionCountUi(AmmunitionManager.instance.GetAmmoCount(weapon.AmmunitionType)); 
        ammunitionTypeText.text = weapon.AmmunitionType.ToString();
        
    }

    public void UpdatedAmmunitionCountUi(int count)
    {
        ammunitionCountText.text = count.ToString();
    }
    
}
