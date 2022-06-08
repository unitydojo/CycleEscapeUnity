using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneBrain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterImage;
    [SerializeField] private Button arrow;
    [Header("Audio")]
    [SerializeField] private AudioSource voiceOverAudioSource;
    [SerializeField] private float playDelay = 0.5f;
    [Space]
    [SerializeField] private Chapter[] chapters;

    [Space] 
    [SerializeField] internal ScenesEnum NextScene;

    [Space] [Header("DEBUG")] 
    [SerializeField] private bool skipChapters = false;
    [SerializeField] private int startChapter = 0;
    
    private int currentIndex = -1;
    private bool showsArrow = false;

    internal virtual void Start()
    {
        if (skipChapters)
        {
            currentIndex = startChapter - 1;
        }
    }

    internal int CurrentSceneIndex()
    {
        return currentIndex;
    }
    
    internal void ShowNextScene()
    {
        SceneManager.LoadScene(NextScene.ToString());
    }
    internal bool HasNextChapter()
    {
        return currentIndex + 1 < chapters.Length;
    }

    internal virtual void ShowedNextChapter(int chapterIndex)
    {
        
    }
    
    internal void ShowNextChapter()
    {
        currentIndex += 1;
        Chapter newChapter = chapters[currentIndex];
        //Load data
        dialogText.text = newChapter.text.Replace("\\n", "\n");;
        characterName.text = newChapter.character.characterName;
        characterName.color = HexColor.ColorFromHex(newChapter.character.hexColor);
        characterImage.sprite = newChapter.character.characterSprite;
        voiceOverAudioSource.clip = newChapter.voiceOver;
        showsArrow = newChapter.showsArrow;
        //Chapter Initial Logic
        voiceOverAudioSource.PlayDelayed(playDelay);
        arrow.gameObject.SetActive(false);
        StartCoroutine(CheckIfAudioFinished());
        this.ShowedNextChapter(currentIndex);
    }

    public void ShowArrow()
    {
        arrow.gameObject.SetActive(true);
        showsArrow = true;
    }
    
    public void SetDialogText(string txt)
    {
        dialogText.text = txt;
    }
    
    private IEnumerator CheckIfAudioFinished()
    {
        yield return new WaitForSeconds(playDelay); //wait for audio to start playing before proceeding
        while (voiceOverAudioSource.isPlaying)
        {
            yield return null; //while audio is playing return and check again on the next frame
        }
        //This code gets executed when stops playing
        if (showsArrow)
        {
            arrow.gameObject.SetActive(true);
        }
    }
}
