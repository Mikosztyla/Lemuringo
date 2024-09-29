using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject customizeFishCard;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject languageSelector;

    private void Awake()
    {
        Instance = this;
        menu.SetActive(false);
        customizeFishCard.SetActive(false);
        playMenu.SetActive(false);
        languageSelector.SetActive(true);
    }

    public void ActiveMenu()
    {
        menu.SetActive(true);
        playMenu.SetActive(false);
        customizeFishCard.SetActive(false);
    }

    public void ActivePlay()
    {
        menu.SetActive(false);
        customizeFishCard.SetActive(false);
        playMenu.SetActive(true);
    }

    public void ActiveCustomizeFishCard()
    {
        menu.SetActive(false);
        customizeFishCard.SetActive(true);
        playMenu.SetActive(false);
        customizeFishCard.GetComponent<CardMenu>().Initialize();
    }
    
}
