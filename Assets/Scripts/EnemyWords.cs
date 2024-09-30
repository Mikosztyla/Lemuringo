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
    private TranslatorApi translatorApi;
    private string firstText;
    private string secondText;
    private string fullLanguage;
    private bool first = true;

    private async void Awake() {
        Instance = this;
        translatorApi = new TranslatorApi("PL", PlayerPrefs.GetString("Lg_y"));
        var textToSay1 = "Podaj tłumaczenie słowa";
        fullLanguage = PlayerPrefs.GetString("Lg_of");
        var textToSay2 = $"po {fullLanguage}";
        var textToSay = await translatorApi.Translate(new[] { textToSay1, textToSay2 });
        firstText = textToSay[textToSay1];
        secondText = textToSay[textToSay2];
        wordSpeak.SetActive(false);
    }

    public void ActivateWord(string word)
    {
        if (first) {
            StartCoroutine(waiter(word));
        }
        else {
            wordSpeak.SetActive(true);
            var wordToSay = $"{firstText} <b>{word}</b> {secondText}";
            wordText.text = wordToSay;
        }
    }

    IEnumerator waiter(string word) {
        yield return new WaitForSeconds(2f);
        first = false;
        ActivateWord(word);
    }
}
