using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private float _distanceRange = 15f;
    private Transform _target;


    void Update()
    {
        FindClosesTarget();
        AimWeapon();
        
    }

    private void FindClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        _target = closestTarget;
    }

    private void AimWeapon()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.position);

        _weapon.LookAt(_target);

        if (distanceToTarget < _distanceRange)
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }

    }

    private void Attack(bool isActive)
    {
        var emissionModule = _particles.emission;
        emissionModule.enabled = isActive;

    }
}
