using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOptionsMenu : MonoBehaviour
{
    private int cardIndex;
    private FishCard fishCard;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button modifyButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        deleteButton.onClick.AddListener(DeleteButton);
        modifyButton.onClick.AddListener(ModifyButton);
        backButton.onClick.AddListener(BackButton);
    }

    public void Initialize(FishCard fishCard, int cardIndex)
    {
        this.cardIndex = cardIndex;
        this.fishCard = fishCard;
    }

    private void DeleteButton()
    {
        CardMenu.Instance.RemoveCard(cardIndex);
        CardMenu.Instance.ShowAllCards();
    }

    private void ModifyButton()
    {
        CardMenu.Instance.ShowModifyCard(fishCard, cardIndex);
    }

    private void BackButton()
    {
        CardMenu.Instance.ShowAllCards();
    }
}
