using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardMenu : MonoBehaviour
{
    public static CardMenu Instance;
    private List<FishCard> fishCards = new();
    private TranslatorApi translatorApi;
    [SerializeField] private AllCardsMenu allCardsMenu;
    [SerializeField] private CardOptionsMenu cardOptionMenu;
    [SerializeField] private ModifyCardMenu modifyCard;
    [SerializeField] private AddNewCardMenu addNewCard;
    [SerializeField] private LanguageSelectorMenu languageSelector;

    private void Awake()
    {
        Instance = this;
        DisableEverything();
    }

    public void Initialize()
    {
        DisableEverything();
        languageSelector.gameObject.SetActive(true);
    }
    
    public void Initialize(string yourLanguage, string otherLanguage)
    {
        translatorApi = new TranslatorApi(yourLanguage, otherLanguage);
    }

    public void DisableEverything()
    {
        allCardsMenu.gameObject.SetActive(false);
        modifyCard.gameObject.SetActive(false);
        cardOptionMenu.gameObject.SetActive(false);
        addNewCard.gameObject.SetActive(false);
    }

    public void ShowAllCards()
    {
        fishCards = SaveFishCardsSystem.LoadFishCards();
        modifyCard.gameObject.SetActive(false);
        allCardsMenu.Initialize(fishCards);
        allCardsMenu.gameObject.SetActive(true);
        cardOptionMenu.gameObject.SetActive(false);
        addNewCard.gameObject.SetActive(false);
    }

    public void ShowCardOptionsMenu(FishCard fishCard, int cardIndex)
    {
        modifyCard.gameObject.SetActive(false);
        allCardsMenu.gameObject.SetActive(false);
        cardOptionMenu.gameObject.SetActive(true);
        addNewCard.gameObject.SetActive(false);
        cardOptionMenu.Initialize(fishCard, cardIndex);
    }
    
    public void ModifyCard(FishCard fishCard, int cardIndex)
    {
        fishCards[cardIndex] = fishCard;
        SaveFishCardsSystem.SaveFishCards(fishCards);
        SaveFishCards();
    }

    public void ShowModifyCard(FishCard fishCard, int cardIndex)
    {
        modifyCard.gameObject.SetActive(true);
        allCardsMenu.gameObject.SetActive(false);
        cardOptionMenu.gameObject.SetActive(false);
        addNewCard.gameObject.SetActive(false);
        modifyCard.Initialize(fishCard, cardIndex);
    }

    public void ShowAddNewCardMenu()
    {
        modifyCard.gameObject.SetActive(false);
        allCardsMenu.gameObject.SetActive(false);
        cardOptionMenu.gameObject.SetActive(false);
        addNewCard.gameObject.SetActive(true);
    }

    public void RemoveCard(int cardIndex)
    {
        fishCards.RemoveAt(cardIndex);
        SaveFishCards();
    }

    public void SaveFishCards()
    {
        SaveFishCardsSystem.SaveFishCards(fishCards);
    }

    public async void AddNewCard(string originalText)
    {
        var fishCard = new FishCard();
        fishCard.OriginalWord = originalText;
        var translatedWords = await translatorApi.Translate(new[] { originalText });
        fishCard.TranslatedWord = translatedWords[originalText];
        fishCards.Add(fishCard);
        SaveFishCards();
    }

}
