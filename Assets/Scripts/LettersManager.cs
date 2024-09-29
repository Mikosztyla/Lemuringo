using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersManager : MonoBehaviour
{
    private Dictionary<string, LetterSO> letters;
    public Color normalColor;
    public Color wrongColor;
    public Color clueColor;

    private void Awake()
    {
        letters = new Dictionary<string, LetterSO>();
        LoadLetters();
    }

    private void LoadLetters()
    {
        LetterSO[] loadedLetters = Resources.LoadAll<LetterSO>("");

        foreach (LetterSO letter in loadedLetters)
        {
            letters.Add(letter.letterName, letter);
        }
    }

    public LetterSO GetLetter(char name)
    {
        name = name.ToString().ToUpper()[0];
        if (letters.ContainsKey(name.ToString())) return letters[name.ToString()];
        return null;
    }
}
