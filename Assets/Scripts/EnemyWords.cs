using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyWords : MonoBehaviour
{
    public static EnemyWords Instance;
    [SerializeField] private GameObject wordSpeak;
    [SerializeField] private TextMeshProUGUI wordText;
    
    private void Awake()
    {
        Instance = this;
        wordSpeak.SetActive(false);
    }

    public void ActivateWord(string word)
    {
        wordSpeak.SetActive(true);
        wordText.text = $"Podaj tlumaczenie slowa <b>{word}</b> po angielsku";
    }
}
