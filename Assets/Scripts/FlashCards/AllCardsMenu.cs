using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCardsMenu : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject addNewCard;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(BuckButtonClick);
    }

    public void Initialize(List<FishCard> fishCards)
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(addNewCard, content.transform);        
        fishCards = SaveFishCardsSystem.LoadFishCards();
        for (int i = 0; i < fishCards.Count; i++)
        {
            var newCard = Instantiate(cardPrefab, content.transform).GetComponent<FlashCardMenu>();
            newCard.SetFlashCard(fishCards[i], i);
        }
    }

    private void BuckButtonClick()
    {
        CardMenu.Instance.DisableEverything();
        MainMenu.Instance.ActiveMenu();
    }
}
