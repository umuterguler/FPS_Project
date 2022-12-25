using Interfaces;
using UnityEngine;

public class DestroyOneHit : MonoBehaviour , IDamageable
{
    public void DealDamage(int damage)
    {
        Destroy(gameObject);
    }
}
