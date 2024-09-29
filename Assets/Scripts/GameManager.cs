using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string yourLanguage;
    [SerializeField] private string otherLanguage;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AllWordsUsed()
    {
        FindObjectOfType<LevelsManager>().LevelPassed();
    }

    public string GetYourLanguage()
    {
        return yourLanguage;
    }

    public void SetYourLanguage(string language)
    {
        this.yourLanguage = language;
    }
    public string GetOtherLanguage()
    {
        return otherLanguage;
    }

    public void SetOtherLanguage(string language)
    {
        this.otherLanguage = language;
    }

    public async void LoadLevel(LevelSO level)
    {
        TranslatorApi translatorApi = new TranslatorApi(yourLanguage, otherLanguage);
        var translatedWords = await translatorApi.Translate(level.words);

        List<string> translatedWordsList = new List<string>();
        foreach (var word in translatedWords)
        {
            translatedWordsList.Add(word.Value);
        }
        GetComponent<WordManager>().LoadNewWords(translatedWordsList, level.words);
        SceneManager.LoadScene(3);
    }

    public void LoadLevel(List<FishCard> fishCards)
    {
        List<string> originalWords = new();
        List<string> translatedWords = new();
        foreach (FishCard fishCard in fishCards)
        {
            originalWords.Add(fishCard.OriginalWord);
            translatedWords.Add(fishCard.TranslatedWord);
        }
        GetComponent<WordManager>().LoadNewWords(originalWords, translatedWords);
        SceneManager.LoadScene(3);
    }
}
