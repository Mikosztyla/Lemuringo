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
    public float shakeAmount = 0.05f;
    private bool isShaking = false;
    private float _damage;

    private void Start()
    {
        letterList = new List<LetterDisplay>();
        lettersManager = FindAnyObjectByType<LettersManager>();
        wordManager = WordManager.Instance;
        SetWordToDisplay(wordManager.GetNewWord());
        _damage = 100f / wordManager.GetAmoutOfWords();
    }

    private void Update()
    {
        if (!Input.anyKeyDown || wordToDisplay == null) return;
        if (Input.GetKeyDown(wordToDisplay[currentLetter].ToString()))
        {
            UpdateWordToDisplay(LetterType.NORMAL);
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
        EnemyWords.Instance.ActivateWord(WordManager.Instance.GetOriginalWord());
        SetUpNewWord();
    }
          
    public void UpdateWordToDisplay(LetterType letterType)
    {
        currLetterDisplay.SetLetterType(letterType);
        switch (letterType)
        {
            case LetterType.NORMAL:
                LeanTween.scale(currLetterDisplay.gameObject, new Vector3(1f, 1f, 1f), 0.1f);
                currentLetter++;
                if (currentLetter == wordToDisplay.Length)
                {
                    WordCompleted();
                    break;
                }
                currLetterDisplay = letterList[currentLetter];
                LeanTween.scale(currLetterDisplay.gameObject, new Vector3(1.2f, 1.2f, 1f), 0.1f);
                break;
            case LetterType.DISABLED:
                if (currentLetter <= 0) break;
                currentLetter--;
                currLetterDisplay = letterList[currentLetter];
                break;
            case LetterType.WRONG:
                if (isShaking) return;
                isShaking = true;
                Vector3 originalPosition = transform.localPosition;
                LeanTween.moveLocal(currLetterDisplay.gameObject, originalPosition + (Vector3.up * UnityEngine.Random.Range(-shakeAmount, shakeAmount)), 0.03f).setLoopPingPong(2).setOnComplete(() =>
                {
                    transform.localPosition = originalPosition;
                    isShaking = false;
                });
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
        LeanTween.scale(currLetterDisplay.gameObject, new Vector3(1.2f, 1.2f, 1f), 0.2f);
    }

    private void WordCompleted()
    {
        Debug.Log("zajebiscie");
        GameObject.FindWithTag("Enemy").GetComponent<HealthBar>().TakeDamage(_damage);
        SetWordToDisplay(wordManager.GetNewWord());
    }
}
