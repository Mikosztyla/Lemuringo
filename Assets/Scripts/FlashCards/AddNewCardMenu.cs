using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddNewCardMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField originalWordInputField;
    [SerializeField] private TMP_InputField translatedWordInputFields;
    [SerializeField] private Button backButton;
    [SerializeField] private Button addCardButton;

    private void Awake()
    {
        backButton.onClick.AddListener(BackButton);
        addCardButton.onClick.AddListener(AddCardButton);
    }

    private void BackButton()
    {
        CardMenu.Instance.ShowAllCards();
    }

    private void AddCardButton()
    {
        Debug.Log(originalWordInputField.text + " " + translatedWordInputFields.text);
    }
}
