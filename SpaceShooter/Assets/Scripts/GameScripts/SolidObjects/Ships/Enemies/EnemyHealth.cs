using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Slider _slider;
    private Transform _parentTransform;

    void Start()
    {
        _slider = transform.GetChild(0).GetComponent<Slider>();
        _parentTransform = transform.parent;
    }

    void FixedUpdate()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(_parentTransform.position + new Vector3 (0,0.8f,0));
    }

    public void SetHealthValue(float value)
    {
        _slider.value = value;
    }
}
