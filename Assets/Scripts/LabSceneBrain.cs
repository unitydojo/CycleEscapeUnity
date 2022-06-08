using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabSceneBrain : SceneBrain
{
    internal override void Start()
    {
        base.Start();
        ShowNextChapter();
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

    public void SafePressed()
    {
        ShowNextChapter();
    }
}
