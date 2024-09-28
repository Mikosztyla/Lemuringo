using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlashCard", menuName = "FlashCard", order = 1)]
public class FlashCardSO : ScriptableObject
{
    public string OriginalWord;
    public string TranslatedWord;
}
