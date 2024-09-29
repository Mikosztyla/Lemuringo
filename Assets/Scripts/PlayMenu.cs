using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private Button levelsButton;
    [SerializeField] private Button customButton;

    private void Awake()
    {
        levelsButton.onClick.AddListener(LevelsButtonClick);
        customButton.onClick.AddListener(CustomButtonClick);
    }

    private void LevelsButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void CustomButtonClick()
    {
        MainMenu.Instance.ActiveCustomizeFishCard();
    }
}
