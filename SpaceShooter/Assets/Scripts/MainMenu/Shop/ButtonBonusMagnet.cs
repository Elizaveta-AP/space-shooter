using System.Collections.Generic;

public class ButtonBonusMagnet : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {10, 16, 22, 28, 34, 40};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetBonusMagnetWorkTime());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetBonusMagnetWorkTime((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBonusMagnetrText();
    }
}