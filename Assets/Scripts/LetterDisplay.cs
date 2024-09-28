using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    [SerializeField] private LetterSO letterDoDisplay;
    [SerializeField] private Image letterImage;

    private LetterType letterType = LetterType.DISABLED;


    private void Start()
    {
        UpdateLetterDisplay();
    }

    public void SetLetterToDisplay(LetterSO letterSO)
    {
        letterDoDisplay = letterSO;
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
                letterImage.sprite = letterDoDisplay.letterImageNormal;
                break;
            case LetterType.WRONG:
                letterImage.enabled = true;
                letterImage.sprite = letterDoDisplay.letterImageWrong;
                break;
            case LetterType.CLUE:
                letterImage.enabled = true;
                letterImage.sprite = letterDoDisplay.letterImageClue;
                break;
        }
    }
}
