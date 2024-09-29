using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    private List<string> words = new();
    private List<string> originalWords = new();
    private int currWord;

    private void Awake()
    {
        Instance = this;
    }

    public string GetNewWord()
    {
        if (currWord == words.Count)
        {
            FindAnyObjectByType<GameManager>().AllWordsUsed();
            return null;
        }
        return words[currWord].ToString();
    }

    public string GetOriginalWord()
    {
        return originalWords[currWord++];
    }

    public void LoadNewWords(List<string> newWords, List<string> originalWords)
    {
        currWord = 0;
        words = newWords;
        this.originalWords = originalWords;
    }
}
