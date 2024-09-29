using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New letter", fileName = "Letter")]
public class LetterSO : ScriptableObject
{
    public string letterName;
    public Sprite letterImageNormal;
    public Sprite letterImageWrong;
}
