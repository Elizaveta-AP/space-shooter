using System.Collections.Generic;

public class ButtonLaserWorkTime : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {10, 16, 22, 28, 34, 40};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetLaserWorkTime());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetLaserWorkTime((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetLaserWorkTimeText();
    }
}