using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Building
{
    [Header("Bonus bank")]
    [SerializeField] private float _bonusCoins = 50;
    [SerializeField] private float _stepTime = 10;

    private float _timeSave;
    
    private void Start()
    {
        _timeSave = _stepTime;
    }
    public void Update()
    {
        AddDetails();
    }
    public void AddDetails()
    {
        if (Purse.Instance.Coins < Purse.Instance.MaxCoins)
        {
            if (_stepTime > 0)
            {
                _stepTime -= Time.deltaTime;

                if (_stepTime <= 0)
                {
                    Purse.Instance.Coins += _bonusCoins;
                    Purse.Instance.UpdateResourcesView();
                    _stepTime = _timeSave;
                }
            }
        }
    }
}
