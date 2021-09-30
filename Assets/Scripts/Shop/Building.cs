using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ConstructionBuildings))]
public class Building : MonoBehaviour
{
    [SerializeField] private float _coins;
    [SerializeField] private int _stars;    
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ConstructionBuildings _constructionBuildings;

    public float Coins => _coins;
    public float Details => _stars;    
    public string Lable => _lable;
    public Sprite Icon => _icon;

    public void Buy(BuildingsGrid buildingsGrid, Menu menu)
    {        
        buildingsGrid.StartPlacingBuilding(_constructionBuildings);
        menu.Close();
    }
}
