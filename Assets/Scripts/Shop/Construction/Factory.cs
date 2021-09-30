using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Factory : Building
{
    [Header("Bonus factory")]
    [SerializeField] private float _bonusDetails = 50;
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
        if (Purse.Instance.Details < Purse.Instance.MaxDetails)
        {
            if (_stepTime > 0)
            {
                _stepTime -= Time.deltaTime;
                if (_stepTime <= 0)
                {
                    Purse.Instance.Details += _bonusDetails;
                    Purse.Instance.UpdateResourcesView();
                    _stepTime = _timeSave;
                }
            }
        }
    }

}
