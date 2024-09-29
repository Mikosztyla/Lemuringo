using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    private List<string> words = new();
    private int currWord;

    public string GetNewWord()
    {
        if (currWord == words.Count)
        {
            FindAnyObjectByType<GameManager>().AllWordsUsed();
            return null;
        }
        return words[currWord++].ToString();
    }

    public void LoadNewWords(List<string> newWords)
    {
        currWord = 0;
        Debug.Log(words);
        words = newWords;
    }
}
