using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    public static CardMenu Instance;
    private List<FishCard> fishCards = new();

    [SerializeField] private AllCardsMenu allCardsMenu;
    [SerializeField] private GameObject addNewCard;

    private void Awake()
    {
        Instance = this;
        ShowAllCards();
    }

    public void ShowAllCards()
    {
        fishCards = SaveFishCardsSystem.LoadFishCards();
        addNewCard.SetActive(false);
        allCardsMenu.Activate(fishCards);
        allCardsMenu.gameObject.SetActive(true);
    }

    public void ShowAddNewCard()
    {
        addNewCard.SetActive(true);
        allCardsMenu.gameObject.SetActive(false);
    }

    public void AddCard(FishCard fishCard)
    {
        fishCards.Add(fishCard);
        SaveFishCardsSystem.SaveFishCards(fishCards);
    }
}
