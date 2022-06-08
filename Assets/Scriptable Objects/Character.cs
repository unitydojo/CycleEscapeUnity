using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character_", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public string hexColor;
}

