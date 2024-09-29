using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject customizeFishCard;

    private void Awake()
    {
        Instance = this;
        menu.SetActive(true);
        customizeFishCard.SetActive(false);
    }

    public void ActiveMenu()
    {
        menu.SetActive(true);
        customizeFishCard.SetActive(false);
    }

    public void ActiveCustomizeFishCard()
    {
        menu.SetActive(false);
        customizeFishCard.SetActive(true);
        customizeFishCard.GetComponent<CardMenu>().Initialize();
    }
    
}
