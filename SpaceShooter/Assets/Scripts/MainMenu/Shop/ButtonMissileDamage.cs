using System.Collections.Generic;

public class ButtonMissileDamage : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {50, 100, 150, 200, 250, 300};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetMissileDamage());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetMissileDamage((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetMissileDamageText();
    }
}