public class ButtonAdditionalGuns : ButtonBuy
{
    public override void Start()
    {
        if (GameSettings.CurrentSettings.GetHasAdditionalGuns()) { CurrentStage = 5; }
        else { CurrentStage = 4; }

        base.Start();
    }


    public override void ChangeValue()
    {
        GameSettings.CurrentSettings.BuyAdditionalGuns();
        PrintPlayerCharacteristics.PrintCharacteristics.SetGunsCountText();
    }
}