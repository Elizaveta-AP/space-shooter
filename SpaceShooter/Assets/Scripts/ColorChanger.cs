using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Animator _animator;
    private bool _isLoaded = false;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        ChangeColor();
        _isLoaded = true;
    }

    void OnEnable()
    {
        if (_isLoaded)
        {
            ChangeColor();
        }
    }


    public void ChangeColor()
    {
        _animator.SetInteger("SlotNumber", GameSettings.CurrentSettings.GetSlot());
    }
}
