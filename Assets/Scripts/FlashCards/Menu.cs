using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button customizeButton;

    private void Awake()
    {
        exitButton.onClick.AddListener(ExitButtonCLick);
        playButton.onClick.AddListener(PlayButtonCLick);
        customizeButton.onClick.AddListener(CustomizeButtonCLick);
    }

    private void ExitButtonCLick()
    {
        Application.Quit();
    }

    private void PlayButtonCLick()
    {
        Debug.Log("Not implemented play button");
        //Load scene
    }

    private void CustomizeButtonCLick()
    {
        MainMenu.Instance.ActiveCustomizeFishCard();
    }
}
