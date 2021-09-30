using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private Button _sellButtonCoins;
    [SerializeField] private TMP_Text _coins;
    [Header("Details")]
    [SerializeField] private Button _sellButtonDetails;
    [SerializeField] private TMP_Text _details;
    [Space]
    [SerializeField] private TMP_Text _lable;
    [Space]
    [SerializeField] private Image _icon;
    
    private Building _building;

    public event UnityAction<Building, ProductView> SellButtonClickCoins;
    public event UnityAction<Building, ProductView> SellButtonClickDetails;
    
    private void OnEnable()
    {
        _sellButtonCoins.onClick.AddListener(OnButtonClickCoin);
        _sellButtonDetails.onClick.AddListener(OnButtonClickDetail);        
    }       
    private void OnButtonClickCoin()
    {        
        SellButtonClickCoins?.Invoke(_building, this);        
    }
    private void OnButtonClickDetail()
    {        
        SellButtonClickDetails?.Invoke(_building, this);                
    }   
    public void Render(Building product)
    {
        _building = product;
        _coins.text = product.Coins.ToString();
        _details.text = product.Details.ToString();
        _lable.text = product.Lable;
        _icon.sprite = product.Icon;
    }     
    private void OnDisable()
    {
        _sellButtonCoins.onClick.RemoveListener(OnButtonClickCoin);
        _sellButtonDetails.onClick.RemoveListener(OnButtonClickDetail);
    }
}
