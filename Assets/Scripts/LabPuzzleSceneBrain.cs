using System.Collections.Generic;
using UnityEngine;

public class LabPuzzleSceneBrain : SceneBrain
{
    private Dictionary<int, bool> answers = new Dictionary<int, bool>();
    internal override void Start()
    {
        base.Start();
        ShowNextChapter();
    }

    public void ArrowPressed()
    {
        ShowNextScene();
    }

    public void Answered(int questionID, bool answer)
    {
        answers[questionID] = answer;
        if (answers.Keys.Count == 7)
        {
            CheckAnswers();
        }
    }

    private void CheckAnswers()
    {
        bool allAnswersAreCorrect = true;
        foreach (var answerId in answers.Keys)
        {
            bool answer = answers[answerId];
            switch (answerId)
            {
                case 1: 
                case 2:
                case 3:
                case 5:
                case 7:
                {
                    bool isExpectedAnswer = answer == false;
                    allAnswersAreCorrect = allAnswersAreCorrect && isExpectedAnswer;
                    break;
                }
                case 4:
                case 6:
                {
                    bool isExpectedAnswer = answer == true;
                    allAnswersAreCorrect = allAnswersAreCorrect && isExpectedAnswer;
                    break;
                }
            }
        }
        if (allAnswersAreCorrect)
        {
            SetDialogText("Σωστά! Τα μυστικά του χρηματοκιβωτίου ανοίγονται μπροστά σου.");
            ShowArrow();
        }
        else
        {
            SetDialogText("Δεν βρήκες τον σωστό συνδυασμό..ακόμα. Συνέχισε να σκέφτεσαι.");
        }
    }
}
