using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public Color disabledColor;
    public Color enabledColor;
    public Color passedColor;
    public List<LevelSO> levels;

    public List<LevelSO> GetLevels()
    {
        return levels;
    }
}
