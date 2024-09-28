using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplayWord : MonoBehaviour
{
    private string wordToDisplay = null;
    private int currentLetter = 0;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private LetterDisplay currLetterDisplay;
    private LettersManager lettersManager;
    private WordManager wordManager;
    private List<LetterDisplay> letterList;


    private void Start()
    {
        letterList = new List<LetterDisplay>();
        lettersManager = FindAnyObjectByType<LettersManager>();
        wordManager = FindAnyObjectByType<WordManager>();
        SetWordToDisplay(wordManager.GetNewWord());
    }

    private void Update()
    {
        if (!Input.anyKeyDown || wordToDisplay == null) return;
        if (Input.GetKeyDown(wordToDisplay[currentLetter].ToString()))
        {
            UpdateWordToDisplay(LetterType.NORMAL);
        } else if (Input.GetKeyDown(KeyCode.Backspace)) {
            UpdateWordToDisplay(LetterType.DISABLED);
        } else
        {
            UpdateWordToDisplay(LetterType.WRONG);
        }
    }

    public void SetWordToDisplay(string wordToDisplay)
    {
        if (wordToDisplay == null) return;
        this.wordToDisplay = wordToDisplay;
        currentLetter = 0;
        SetUpNewWord();
    }
          
    public void UpdateWordToDisplay(LetterType letterType)
    {
        currLetterDisplay.SetLetterType(letterType);
        switch (letterType)
        {
            case LetterType.NORMAL:
                currentLetter++;
                if (currentLetter == wordToDisplay.Length)
                {
                    WordCompleted();
                    break;
                }
                currLetterDisplay = letterList[currentLetter];
                break;
            case LetterType.DISABLED:
                if (currentLetter <= 0) break;
                currentLetter--;
                currLetterDisplay = letterList[currentLetter];
                break;
        } 
    }

    public void SetUpNewWord()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        letterList = new List<LetterDisplay>();

        foreach (Char c in wordToDisplay)
        {
            GameObject go = Instantiate(letterPrefab, transform);
            go.GetComponent<LetterDisplay>().SetLetterToDisplay(lettersManager.GetLetter(c));
            letterList.Add(go.GetComponent<LetterDisplay>());
        }

        currLetterDisplay = letterList[currentLetter];
    }

    private void WordCompleted()
    {
        Debug.Log("zajebiscie");
        SetWordToDisplay(wordManager.GetNewWord());
    }
}
