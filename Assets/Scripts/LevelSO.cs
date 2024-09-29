using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Level", fileName = "New Level")]
public class LevelSO : ScriptableObject
{
    public int levelId;
    public List<string> words;
    public bool levelEnabled = false;
    public bool levelPassed = false;
}
