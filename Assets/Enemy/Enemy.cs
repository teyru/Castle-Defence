using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _goldPerKill = 25;
    [SerializeField] private int _goldPerSteal = 25;

    private Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void EarnGold()
    {
        if (bank == null) { return; }
        bank.Deposit(_goldPerKill);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(_goldPerSteal);
    }

}
