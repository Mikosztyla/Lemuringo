using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ModifyCardMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField originalWordInputField;
    [SerializeField] private TMP_InputField translatedWordInputFields;
    [SerializeField] private Button backButton;
    [SerializeField] private Button modifyCardButton;
    private int cardIndex;
    private void Awake()
    {
        backButton.onClick.AddListener(BackButton);
        modifyCardButton.onClick.AddListener(ModifyCardButton);
    }

    public void Initialize(FishCard fishCard, int cardIndex)
    {
        this.cardIndex = cardIndex;
        originalWordInputField.text = fishCard.OriginalWord;
        translatedWordInputFields.text = fishCard.TranslatedWord;
    }

    private void BackButton()
    {
        CardMenu.Instance.ShowAllCards();
    }

    private void ModifyCardButton()
    {
        var newFishCard = new FishCard();
        newFishCard.OriginalWord = originalWordInputField.text;
        newFishCard.TranslatedWord = translatedWordInputFields.text;
        CardMenu.Instance.ModifyCard(newFishCard, cardIndex);
        CardMenu.Instance.ShowAllCards();
    }
}
