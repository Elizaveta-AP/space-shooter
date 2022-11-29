using System.Collections.Generic;

public class ButtonBulletSpeed : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {5, 10, 15, 20, 25, 30};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetBulletSpeed());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetBulletSpeed((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBulletSpeedText();
    }
}