using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScenebrain : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonClickSound;
    [Header("Settings")] 
    [SerializeField] private float dissolveDuration = 2f;
    
    #region Private vars
    
    private bool startButtonClicked = false;
    private bool shouldNotUpdate = true;
    private float dissolveTimePassed = 0f;
    
    #endregion

    private void Start()
    {
        audioSource.Play(); //WebGL autoplay is disabled so do it manually
    }
    
    private void Update()
    {
        if (shouldNotUpdate) return;
        audioSource.volume = Mathf.Lerp(1, 0, dissolveTimePassed/dissolveDuration);
        dissolveTimePassed += Time.deltaTime;
        if (dissolveTimePassed >= dissolveDuration)
        {
            shouldNotUpdate = true;
            ShowNextScene();
        }
    }

    public void OnStartButtonClick()
    {
        if (startButtonClicked) return; //avoid multiple clicks
        audioSource.PlayOneShot(buttonClickSound);
        startButtonClicked = true;
        shouldNotUpdate = false;
    }

    private void ShowNextScene()
    {
        SceneManager.LoadScene(ScenesEnum.LivingRoomScene.ToString());
    }
}
