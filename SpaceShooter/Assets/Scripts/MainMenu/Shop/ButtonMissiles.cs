public class ButtonMissiles : ButtonBuy
{
    public override void Start()
    {
        CurrentStage = 0;
        base.Start();
    }


    public override void Buy()
    {
        if (GameSettings.CurrentSettings.SpendCoins(Price[CurrentStage]))
        {
            GameSettings.CurrentSettings.BuyMissile();
            PrintPlayerCharacteristics.PrintCharacteristics.SetMissilesCountText();
        }
    }
}