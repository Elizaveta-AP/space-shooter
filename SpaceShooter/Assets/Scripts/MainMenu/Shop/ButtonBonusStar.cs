using System.Collections.Generic;

public class ButtonBonusStar : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {10, 16, 22, 28, 34, 40};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetBonusStarWorkTime());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetBonusStarWorkTime((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBonusStarText();
    }
}