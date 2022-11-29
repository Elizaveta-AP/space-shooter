using System.Collections.Generic;

public class ButtonShipHealth : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {100, 200, 400, 700, 1000, 1500};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetMaxHealth());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetMaxHealth((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetShipHealthText();
    }
}