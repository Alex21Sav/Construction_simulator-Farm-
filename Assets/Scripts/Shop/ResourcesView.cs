using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesView : MonoBehaviour
{
    [SerializeField] private Purse _purse;
    [SerializeField] private TMP_Text _coin;
    [SerializeField] private TMP_Text _maxCoin;
    [SerializeField] private TMP_Text _detail;
    [SerializeField] private TMP_Text _maxDetail;

    private void OnEnable()
    {
        _purse.ResourcesChanget += OnResourcesChanget;
        _purse.MaxResourcesChanget += OnMaxResourcesChanget;
    }
    private void OnResourcesChanget(float coin, float detail)
    {
        _coin.text = coin.ToString();
        _detail.text = detail.ToString();
    }
    private void OnMaxResourcesChanget(float maxCoin, float maxDetail)
    {
        _maxCoin.text = maxCoin.ToString();
        _maxDetail.text = maxDetail.ToString();
    }
    private void OnDisable()
    {
        _purse.ResourcesChanget -= OnResourcesChanget;
        _purse.MaxResourcesChanget -= OnMaxResourcesChanget;
    }    
}
