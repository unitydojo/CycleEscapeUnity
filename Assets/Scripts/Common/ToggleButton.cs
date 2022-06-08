using System;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Button otherButton;
    [SerializeField] private int questionID;
    [SerializeField] private bool truthValue;

    private Image buttonImage;
    private ToggleButton otherButtonBrain;
    private bool selected = false;
    private LabPuzzleSceneBrain sceneBrain;

    private void Start()
    {
        sceneBrain = GameObject.Find("/SceneBrain").GetComponent<LabPuzzleSceneBrain>();
        buttonImage = GetComponent<Image>();
        otherButtonBrain = otherButton.GetComponent<ToggleButton>();
    }

    public void OnClickToggle()
    {
        selected = true;
        buttonImage.sprite = onSprite;
        otherButtonBrain.Disable();
        sceneBrain.Answered(questionID, truthValue);
    }

    public void Disable()
    {
        buttonImage.sprite = offSprite;
        enabled = false;
    }
}
