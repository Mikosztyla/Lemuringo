using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private List<string> words;
    private int currWord = 0;

    private void Start()
    {
        words = new List<string>
        {
            "abcd",
            "aaa",
            "bbbbbbb",
            "c"
        };
    }

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
        words = newWords;
    }
}
