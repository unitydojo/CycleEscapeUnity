using UnityEngine;
[CreateAssetMenu(fileName = "Chapter_", menuName = "Chapter")]
public class Chapter : ScriptableObject
{
    [Header("Chapter Data")]
    public string text;
    public AudioClip voiceOver;
    public bool showsArrow = true;
    
    [Header("Character")]
    public Character character;
}
