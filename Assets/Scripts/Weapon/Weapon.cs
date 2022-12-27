using System;
using Interfaces;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [Header("Weapon Stuffs")]
    public string weaponName;
    public GameObject weaponPickup;
    [SerializeField] private Transform muzzleTransform;
    
    [Header("Weapon Stats")]
    public AmmunitionTypes AmmunitionType;
    public int minDamage;
    public int maxDamage;
    public float maxRange;
    public float fireRate;

    protected float timeOfLastShot;

    [Header("Effects")]
    [SerializeField]private GameObject hitEffect;
    [SerializeField]private TrailRenderer bulletTracer;
    [SerializeField]private ParticleSystem[] muzzleFlash;


    #region Fire
    protected void Fire()
    {
        if (AmmunitionManager.instance.ConsumeAmmo(AmmunitionType))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var whatIHit, maxRange))
            {
                #region Damage
                IDamageable damageable = whatIHit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                { 
                    float normalizedDistance = whatIHit.distance / maxRange; 
                    if (normalizedDistance <= 1) 
                    { 
                        damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(maxDamage, minDamage, normalizedDistance))); 
                    }
                }
                #endregion
                
                #region HitEffect
                if (hitEffect != null)
                {
                    GameObject hitEffectInstance = Instantiate(hitEffect, whatIHit.point, Quaternion.identity);
                    hitEffectInstance.transform.forward = whatIHit.normal;
                    hitEffectInstance.transform.SetParent(whatIHit.transform);
                }
                #endregion
            }
            
            #region FireEffects
            
            foreach (var particle in muzzleFlash) //Muzzle Flash
            { 
                particle.Emit(1);
            }
            
            var muzzlePos = muzzleTransform.position; //Bullet Tracer
            var tracer = Instantiate(bulletTracer, muzzlePos, Quaternion.identity); tracer.AddPosition(muzzlePos);
            tracer.transform.position = ray.GetPoint(maxRange); 

            #endregion
        }
    }
    #endregion
    
}
