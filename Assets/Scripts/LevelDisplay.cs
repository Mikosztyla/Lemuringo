using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private LevelSO levelSO;
    [SerializeField] private TextMeshProUGUI levelNumber;
    [SerializeField] private Image levelImage;

    private LevelsManager levelsManager;

    private void Start()
    {
        levelsManager = FindAnyObjectByType<LevelsManager>();
        if (levelSO != null) levelNumber.text = levelSO.levelId.ToString();
        levelImage.color = levelsManager.disabledColor;
    }

    public void EnableLevel()
    {
        levelImage.color = levelsManager.enabledColor;
    }

    public void PassLevel()
    {
        levelImage.color = levelsManager.passedColor;
    }

    public void SetLevelSO(LevelSO levelSO)
    {
        this.levelSO = levelSO;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        if (levelSO == null) return;
        if (levelSO.levelEnabled) EnableLevel();
        if (levelSO.levelPassed) PassLevel();

        levelNumber.text = levelSO.levelId.ToString();
    }
}
