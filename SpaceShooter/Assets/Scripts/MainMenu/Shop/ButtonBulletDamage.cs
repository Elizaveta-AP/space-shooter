using System.Collections.Generic;

public class ButtonBulletDamage : ButtonBuy
{
    public override void Start()
    {
        Values = new float[6] {5, 10, 15, 20, 25, 30};
        CurrentStage = ((IList<float>)Values).IndexOf(GameSettings.CurrentSettings.GetBulletDamage());

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.SetBulletDamage((int)Values[CurrentStage]);
        PrintPlayerCharacteristics.PrintCharacteristics.SetBulletDamageText();
    }
}