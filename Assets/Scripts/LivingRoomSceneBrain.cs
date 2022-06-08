public class LivingRoomSceneBrain : SceneBrain
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
}
