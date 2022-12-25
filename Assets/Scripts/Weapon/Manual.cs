using UnityEngine;

public class Manual : Weapon
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - timeOfLastShot >= 1/fireRate)
            {
                Fire();
                timeOfLastShot = Time.time;
            }
        }
    }
}
