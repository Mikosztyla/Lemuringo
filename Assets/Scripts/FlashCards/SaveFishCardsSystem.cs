using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveFishCardsSystem
{
    public static void SaveFishCards(List<FishCard> fishCards)
    {
        var fishCardsList = new FishCards();
        fishCardsList.FishCardsList = fishCards;
        string json = JsonUtility.ToJson(fishCardsList);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/FishCards.json", json);
    }

    public static List<FishCard> LoadFishCards()
    {
        var fishCards = JsonUtility.FromJson<FishCards>(System.IO.File.ReadAllText(Application.persistentDataPath + "/FishCards.json"));

        return fishCards.FishCardsList;
    }
}
