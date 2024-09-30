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
        levelImage.color = Color.white;
        GetComponent<Button>().interactable = true;
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

    public LevelSO GetLevelSO() { return levelSO; }

    public void UpdateLevel()
    {
        if (levelSO == null) return;
        if (levelSO.levelId is 1 or 2 or 3) EnableLevel();
        else GetComponent<Button>().interactable = false;

        // if (levelSO.levelPassed) PassLevel();

        levelNumber.text = levelSO.levelId.ToString();
    }
}
