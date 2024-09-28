using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    public static CardMenu Instance;
    
    [SerializeField] private GameObject allCards;
    [SerializeField] private GameObject addNewCard;

    private void Awake()
    {
        Instance = this;
        addNewCard.SetActive(false);
    }

    public void ShowAllCards()
    {
        addNewCard.SetActive(false);
        allCards.SetActive(true);
    }

    public void ShowAddNewCard()
    {
        addNewCard.SetActive(true);
        allCards.SetActive(false);
    }
}
