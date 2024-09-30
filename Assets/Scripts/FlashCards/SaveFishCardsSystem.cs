using System;
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

    public static List<FishCard> LoadFishCards() {
        FishCards fishCards;
        try {
            fishCards = JsonUtility.FromJson<FishCards>(System.IO.File.ReadAllText(Application.persistentDataPath + "/FishCards.json"));
        }
        catch (Exception e) {
            var json = "{}";
            System.IO.File.WriteAllText(Application.persistentDataPath + "/FishCards.json", json);
            return new List<FishCard>();
        }

        return fishCards.FishCardsList;
    }
}
