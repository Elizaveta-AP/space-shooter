using System.Collections.Generic;

public class ButtonShootDelay : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {1.0f, 0.88f, 0.76f, 0.64f, 0.52f, 0.4f};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetShootDelay());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetShootDelay(Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetShootDelayText();
    }
}