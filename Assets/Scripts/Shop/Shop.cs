using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Building> _product;
    [SerializeField] private Purse _purse;
    [SerializeField] private ProductView _templateView;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private BuildingsGrid _buildingsGrid;
    [SerializeField] private Menu _menu;

    private void Start()
    {
        for (int i = 0; i < _product.Count; i++)
        {
            ProcessingArrays(_product[i]);
        }
        for (int i = 0; i < _product.Count; i++)
        {
            AddItem(_product[i]);
        }
    }
    private void AddItem(Building product)
    {
        var view = Instantiate(_templateView, _itemContainer.transform);
        view.SellButtonClickCoins += OnSellCoinsButtonClick;
        view.SellButtonClickDetails += OnSellStarsButtonClick;
        view.Render(product);
    }
    public void OnSellCoinsButtonClick(Building product, ProductView view)
    {
        if (product.Coins <= _purse.Coins)
        {
            _purse.BuyProductCoins(product);
            product.Buy(_buildingsGrid, _menu);
            view.Render(product);
        }
    }
    public void OnSellStarsButtonClick(Building product, ProductView view)
    {
        if (product.Details <= _purse.Details)
        {
            _purse.BuyProductStars(product);
            product.Buy(_buildingsGrid, _menu);
            view.Render(product);
        }
    }
    private void ProcessingArrays(Building product)
    {
        _product = _product.OrderBy(product => product.Coins).ThenBy(product => product.Details).ToList();
    }
}
