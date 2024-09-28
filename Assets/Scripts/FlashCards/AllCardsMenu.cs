using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCardsMenu : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject cardPrefab;
    
    public void Activate(List<FishCard> fishCards)
    {
        fishCards = SaveFishCardsSystem.LoadFishCards();
        foreach (var flashCard in fishCards)
        {
            var newCard = Instantiate(cardPrefab, content.transform).GetComponent<FlashCardMenu>();
            Debug.Log(newCard.name);
            newCard.SetFlashCard(flashCard);
        }
    }
}
