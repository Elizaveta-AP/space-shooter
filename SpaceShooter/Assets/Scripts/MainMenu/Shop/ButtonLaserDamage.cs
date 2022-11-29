using System.Collections.Generic;

public class ButtonLaserDamage : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {1, 2, 3, 4, 5, 6};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetLaserDamage());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetLaserDamage((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetLaserDamageText();
    }
}