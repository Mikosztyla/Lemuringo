using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    [SerializeField] private LetterSO letterToDisplay;
    [SerializeField] private Image letterImage;
    [SerializeField] private Image baseImage;

    private LetterType letterType = LetterType.DISABLED;
    private LettersManager lettersManager;


    private void Start()
    {
        lettersManager = FindAnyObjectByType<LettersManager>();
        UpdateLetterDisplay();
    }

    public void SetLetterToDisplay(LetterSO letterSO)
    {
        letterToDisplay = letterSO;
        letterImage.sprite = letterSO.letterImageNormal;
    }

    public void SetLetterType(LetterType letterType)
    {
        this.letterType = letterType;
        UpdateLetterDisplay();
    }

    void UpdateLetterDisplay()
    {
        switch (letterType)
        {
            case LetterType.DISABLED:
                letterImage.enabled = false;
                break;
            case LetterType.NORMAL:
                letterImage.enabled = true;
                letterImage.color = lettersManager.normalColor;
                letterImage.sprite = letterToDisplay.letterImageNormal;
                baseImage.color = lettersManager.normalColor;
                break;
            case LetterType.WRONG:
                letterImage.enabled = true;
                letterImage.color = lettersManager.wrongColor;
                letterImage.sprite = letterToDisplay.letterImageWrong;
                baseImage.color = lettersManager.wrongColor;
                break;
            case LetterType.CLUE:
                letterImage.enabled = true;
                letterImage.color = lettersManager.clueColor;
                baseImage.color = lettersManager.clueColor;
                break;
        }
    }
}
