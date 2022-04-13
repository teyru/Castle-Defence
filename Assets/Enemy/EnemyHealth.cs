using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private int _difficulty = 1;
    [SerializeField] private int _currentHealth = 0;

    private Enemy enemy;

    void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            enemy.EarnGold();
            _maxHealth += _difficulty;
            gameObject.SetActive(false);
        }
            
    }
}
