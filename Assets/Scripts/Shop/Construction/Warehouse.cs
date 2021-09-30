using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : Building
{
    [Header("Bonus warehouse")]
    [SerializeField] private float _addMaxDetails;

    private void Start()
    {
        Purse.Instance.MaxDetails += _addMaxDetails;
        Purse.Instance.UpdateMaxResourcesView();
    }

}
