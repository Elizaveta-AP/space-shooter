using System.Collections.Generic;

public class ButtonLaserLoadTime : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {180, 160, 140, 120, 90, 60};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetLaserLoadTime());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetLaserLoadTime((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetLaserLoadTimeText();
    }
}