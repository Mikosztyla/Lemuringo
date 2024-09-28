using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCardsMenu : MonoBehaviour
{
    [SerializeField] private List<FlashCardSO> flashCardsSO = new();
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject cardPrefab;
    
    void Awake()
    {
        foreach (var flashCard in flashCardsSO)
        {
            var newCard = Instantiate(cardPrefab, content.transform).GetComponent<FlashCardMenu>();
            Debug.Log(newCard.name);
            newCard.SetFlashCard(flashCard);
        }
    }
}
