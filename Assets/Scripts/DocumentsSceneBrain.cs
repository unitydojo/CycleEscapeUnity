using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentsSceneBrain : SceneBrain
{
    [Header("Audio")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip errorSound;
    
    [Header("UI")]
    [SerializeField] private GameObject circle_1;
    [SerializeField] private GameObject circle_2;
    [SerializeField] private GameObject circle_3;
    [SerializeField] private GameObject answersParent;

    private int pendingDocuments = 3;
    internal override void Start()
    {
        base.Start();
        SetupUI();
        ShowNextChapter();
    }

    private void SetupUI()
    {
        circle_1.SetActive(false);
        circle_2.SetActive(false);
        circle_3.SetActive(false);
        answersParent.SetActive(false);
    }

    public void ArrowPressed()
    {
        if (HasNextChapter())
        {
            ShowNextChapter();    
        }
        else
        {
            ShowNextScene();
        }
    }

    internal override void ShowedNextChapter(int chapterIndex)
    {
        if (chapterIndex <= 4)
        {
            //used >= to allow debug by skip of chapters
            circle_1.SetActive(true);
            circle_3.SetActive(chapterIndex >= 1);
            circle_2.SetActive(chapterIndex >= 2);
            answersParent.SetActive(chapterIndex >= 4);
        }
        
    }

    public void PlayErrorSound() //called when user drags a circle to a wrong position
    {
        _audioSource.PlayOneShot(errorSound);
    }
    
    public void DocumentTimeOrderFound(int documentID) //called when user drags a circle to its correct time position
    {
        pendingDocuments -= 1;
        if (pendingDocuments == 0)
        {
            CleanUI();
            ShowNextChapter();
        }
    }

    private void CleanUI()
    {
        Destroy(circle_1);
        Destroy(circle_2);
        Destroy(circle_3);
        Destroy(answersParent);
    }
}
