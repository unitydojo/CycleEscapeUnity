using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacebookSceneBrain : SceneBrain
{
    [Header("UI")]
    [SerializeField] private GameObject tickEmail;
    [SerializeField] private GameObject tickBand;
    
    private bool foundEmail;
    private bool foundBandName;
    internal override void Start()
    {
        base.Start();
        ShowNextChapter();
    }

    public void ItemClicked(bool isEmail, bool isBandName)
    {
        if (isEmail)
        {
            foundEmail = true;
            tickEmail.SetActive(true);
        } else if (isBandName)
        {
            tickBand.SetActive(true);
            foundBandName = true;
        }
        CheckIfFinished();
    }

    private void CheckIfFinished()
    {
        if (foundEmail && foundBandName)
        {
            StartCoroutine(SceneCompleted());
        }
    }
    
    private IEnumerator SceneCompleted()
    {
        yield return new WaitForSeconds(2.0f);
        ShowNextScene();
    }
}
