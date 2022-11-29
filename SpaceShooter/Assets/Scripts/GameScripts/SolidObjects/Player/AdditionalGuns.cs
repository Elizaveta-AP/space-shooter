using UnityEngine;

public class AdditionalGuns : MonoBehaviour
{
    [SerializeField] private GameObject[] AdditionalHolders;
    
    private void Start() 
    {
        if (GameSettings.CurrentSettings.GetHasAdditionalGuns())
        {
            foreach (GameObject gun in AdditionalHolders)
            {
                gun.SetActive(true);
            }
        }
    }
}