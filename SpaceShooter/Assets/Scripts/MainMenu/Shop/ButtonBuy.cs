using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ButtonBuy : MonoBehaviour
{
    protected int[] Price = new int[5] {25, 50, 100, 250, 500};
    protected int CurrentStage;
    protected float[] Values;
    protected Button ThisButton;
    protected TMP_Text PriceText;


    public virtual void Start()
    {
        ThisButton = GetComponent<Button>();
        PriceText = transform.Find("TextPrice").GetComponent<TMP_Text>();

        CheckStage();
    }

    
    public virtual void Buy()
    {
        if (GameSettings.CurrentSettings.SpendCoins(Price[CurrentStage]))
        {
            CurrentStage++;
            ChangeValue();
            CheckStage();
        }
    }


    public virtual void ChangeValue()
    {

    }


    protected void CheckStage()
    {
        if (CurrentStage == 5) { MakeNonInteractable(); }
        else { SetPriceText(); }
    }


    protected void SetPriceText()
    {
        PriceText.text = Price[CurrentStage].ToString();
    }


    protected void MakeNonInteractable()
    {
        ThisButton.interactable = false;
    }
}