using System.Collections.Generic;

public class ButtonBousShield : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {10, 16, 22, 28, 34, 40};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetBonusShieldWorkTime());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetBonusShieldWorkTime((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBonusShieldText();
    }
}