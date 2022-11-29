using System.Collections.Generic;

public class ButtonShipSpeed : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {5, 6, 7, 8, 9, 10};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetSpeed());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetSpeed((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetShipSpeedText();
    }
}