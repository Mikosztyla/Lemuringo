using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewCardButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(AddNewCard);  
    }

    private void AddNewCard()
    {
        CardMenu.Instance.ShowAddNewCardMenu();
    }
}
