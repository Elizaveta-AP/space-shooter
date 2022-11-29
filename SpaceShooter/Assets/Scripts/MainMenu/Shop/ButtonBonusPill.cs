using System.Collections.Generic;

public class ButtonBonusPill : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {50, 100, 200, 350, 500, 750};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetPillHealthCount());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetPillHealthCount((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBonusPillText();
    }
}