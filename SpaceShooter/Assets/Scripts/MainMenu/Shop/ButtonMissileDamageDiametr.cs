using System.Collections.Generic;

public class ButtonMissileDamageDiametr : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {2.0f, 2.4f, 2.8f, 3.2f, 3.6f, 4.0f};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetMissileDamageDiametr());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetMissileDamageDiametr(Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetMissileDamageDiametrText();
    }
}