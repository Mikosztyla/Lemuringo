using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(LevelDisplay levelDisplay)
    {
        FindAnyObjectByType<GameManager>().LoadLevel(levelDisplay.GetLevelSO());
    }
}
