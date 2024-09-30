using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public Color disabledColor;
    public Color enabledColor;
    public Color passedColor;
    public List<LevelSO> levels;
    private int nextLevelToUnlock = 0;

    private void Start()
    {
        foreach (LevelSO levelSO in levels) {
            if (!levelSO.levelEnabled) break;
            nextLevelToUnlock++;
        }
    }

    public List<LevelSO> GetLevels()
    {
        return levels;
    }

    public void LevelPassed()
    {
        // levels[nextLevelToUnlock-1].levelPassed = true;
        // levels[nextLevelToUnlock].levelEnabled = true;
        SceneManager.LoadScene(2);
        // FindObjectOfType<LevelsLoader>().UpdateLevels();
    }
}
