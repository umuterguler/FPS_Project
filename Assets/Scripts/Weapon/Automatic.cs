using UnityEngine;

public class Automatic : Weapon
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - timeOfLastShot >= 1/fireRate)
            {
                Fire();
                timeOfLastShot = Time.time;
            }
        }
    }
}
