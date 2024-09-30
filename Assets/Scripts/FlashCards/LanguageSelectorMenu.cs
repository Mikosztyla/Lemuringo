using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelectorMenu : MonoBehaviour
{
    private Dictionary<string, string> languageDictionary = new();

    [SerializeField] private TMP_Dropdown myLanguageDropdown;
    [SerializeField] private TMP_Dropdown otherLanguageDropdown;
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(ContinueCLick);
        var languageDictionarySerializable = JsonUtility.FromJson<LanguageDictionary>(Resources.Load<TextAsset>("Languages").ToString());
        for (int i = 0; i < languageDictionarySerializable.languageDictionaryKey.Count; i++)
        {
            languageDictionary.Add(languageDictionarySerializable.languageDictionaryValue[i], languageDictionarySerializable.languageDictionaryKey[i]);
        }
        myLanguageDropdown.ClearOptions();
        myLanguageDropdown.AddOptions(languageDictionarySerializable.languageDictionaryValue);
        otherLanguageDropdown.ClearOptions();
        otherLanguageDropdown.AddOptions(languageDictionarySerializable.languageDictionaryValue);
    }

    private void ContinueCLick()
    {
        CardMenu.Instance.Initialize(languageDictionary[myLanguageDropdown.captionText.text], languageDictionary[otherLanguageDropdown.captionText.text]);
        MainMenu.Instance.ActiveMenu();
        PlayerPrefs.SetString("Lg_y", languageDictionary[myLanguageDropdown.captionText.text]);
        PlayerPrefs.SetString("Lg_o", languageDictionary[otherLanguageDropdown.captionText.text]);
        PlayerPrefs.SetString("Lg_of", otherLanguageDropdown.captionText.text);
        Destroy(gameObject);
    }
}
