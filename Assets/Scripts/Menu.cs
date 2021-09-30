using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _shop;

    private void Awake()
    {
        _shop.SetActive(true);        
        _mainMenu.SetActive(true);
    }
    private void Start()
    {
        _shop.SetActive(false);        
        _mainMenu.SetActive(false);
    }
    public void Shop()
    {
        _shop.SetActive(true);        
        _mainMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        _shop.SetActive(false);        
        _mainMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Open()
    {
        _mainMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Close()
    {
        _shop.SetActive(false);
        _mainMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ToggleOpen()
    {
        if (_shop.activeSelf || _mainMenu.activeSelf)
            Close();
        else
            Open();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
