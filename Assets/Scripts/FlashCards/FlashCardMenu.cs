using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FlashCardMenu : MonoBehaviour
{
    private FlashCardSO flashCardSo;
    [SerializeField] private TextMeshProUGUI originalText;
    [SerializeField] private TextMeshProUGUI translatedText;

    public void SetFlashCard(FlashCardSO flashCard)
    {
        flashCardSo = flashCard;
        originalText.text = flashCard.OriginalWord;
        translatedText.text = flashCard.TranslatedWord;
    }
}
