using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FlashCardMenu : MonoBehaviour
{
    private FishCard flashCardSo;
    [SerializeField] private TextMeshProUGUI originalText;
    [SerializeField] private TextMeshProUGUI translatedText;
    private int cardIndex;
    private FishCard fishCard;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void SetFlashCard(FishCard flashCard, int cardIndex)
    {
        flashCardSo = flashCard;
        fishCard = flashCard;
        originalText.text = flashCard.OriginalWord;
        translatedText.text = flashCard.TranslatedWord;
        this.cardIndex = cardIndex;
    }

    private void Click()
    {
        CardMenu.Instance.ShowCardOptionsMenu(fishCard, cardIndex);
    }
}
