using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AddNewCardMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField originalWordInputField;
    [SerializeField] private Button backButton;
    [SerializeField] private Button addCardButton;
    private int cardIndex;
    private void Awake()
    {
        backButton.onClick.AddListener(BackButton);
        addCardButton.onClick.AddListener(AddNewCardButton);
    }

    private void BackButton()
    {
        CardMenu.Instance.ShowAllCards();
    }

    private void AddNewCardButton()
    {
        CardMenu.Instance.AddNewCard(originalWordInputField.text);
        originalWordInputField.text = string.Empty;
    }
}
