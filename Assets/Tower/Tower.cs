using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private int _cost = 75;

    public bool CreateTower(Tower towerPrefab, Vector3 Position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false; 
        }

        if(bank.CurrentBalance >= _cost)
        {
            Instantiate(towerPrefab, Position, Quaternion.identity);
            bank.Withdraw(_cost);
            return true;
        }

        return false;
    }
}
