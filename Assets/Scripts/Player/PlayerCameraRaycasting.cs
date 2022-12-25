using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRaycasting : MonoBehaviour
{
    private ILootable currentTarget;
    [SerializeField] private float raycastDistance;

    void Update()
    {
        HandleRaycasting();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTarget != null)
            {
                currentTarget.OnLookInteracted();
            }
        }
    }

    private void HandleRaycasting()
    {
        RaycastHit WhatIHit;
        if (Physics.Raycast(transform.position, transform.forward, out WhatIHit, raycastDistance))
        {
            ILootable lootable = WhatIHit.collider.GetComponent<ILootable>();
            if (lootable != null)
            {
                if (lootable == currentTarget)
                    return;
                else if (currentTarget != null)
                {
                    currentTarget.OnLookStopped();
                    currentTarget = lootable;
                    currentTarget.OnLookStarted();
                }
                else
                {
                    currentTarget = lootable;
                    currentTarget.OnLookStarted();
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnLookStopped();
                    currentTarget = null;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnLookStopped();
                currentTarget = null;
            }
        }
    }
}
