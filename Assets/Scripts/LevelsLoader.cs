using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLoader : MonoBehaviour
{
    [SerializeField] Transform levelsTransform;

    private void Start()
    {
        List<LevelSO> levels = FindAnyObjectByType<LevelsManager>().GetLevels();
        int counter = 0;
        foreach (Transform t in levelsTransform)
        {
            t.gameObject.GetComponent<LevelDisplay>().SetLevelSO(levels[counter++]);
        }
    }

    public void UpdateLevels()
    {
        foreach (Transform t in levelsTransform)
        {
            t.gameObject.GetComponent<LevelDisplay>().UpdateLevel();
        }
    }
}
