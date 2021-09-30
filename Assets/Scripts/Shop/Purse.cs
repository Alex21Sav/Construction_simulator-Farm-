using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Purse : MonoBehaviour
{
    public static Purse Instance;

    [SerializeField] private Factory _factory;

    public float Coins;
    public float Details;

    public float MaxCoins = 1000;
    public float MaxDetails = 1000;

    public event UnityAction<float, float> ResourcesChanget;
    public event UnityAction<float, float> MaxResourcesChanget;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        UpdateResourcesView();
        UpdateMaxResourcesView();
    }    
    public void BuyProductCoins(Building building)
    {
        Coins -= building.Coins;
        UpdateResourcesView();
        Debug.Log($"You bought {building.Lable}");
    }
    public void BuyProductStars(Building building)
    {
        Details -= building.Details;
        UpdateResourcesView();
        Debug.Log($"You bought {building.Lable}");
    }
    public void UpdateResourcesView()
    {
        ResourcesChanget?.Invoke(Coins, Details);
    }
    public void UpdateMaxResourcesView()
    {
        MaxResourcesChanget?.Invoke(MaxCoins, MaxDetails);
    }
}
