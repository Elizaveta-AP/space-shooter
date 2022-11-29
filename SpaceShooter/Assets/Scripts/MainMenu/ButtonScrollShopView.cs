using UnityEngine;
using UnityEngine.UI;

public class ButtonScrollShopView : MonoBehaviour
{
    [SerializeField] private Scrollbar _horizontalScrollbar;
    private int _numberOfSteps;
    private float _stepSize;
    public enum Directon {left = -1, right = 1};
    public Directon _direction;

    void Start()
    {
        _numberOfSteps = _horizontalScrollbar.numberOfSteps;
        _stepSize = 1.0f / (_numberOfSteps - 1.0f);
    }

    public void ScrollShopView()
    {
        float newValue = _horizontalScrollbar.value + _stepSize * (int)_direction;

        if (newValue > 1) { newValue = 0; }
        else if (newValue < 0) { newValue = 1; }

        _horizontalScrollbar.value = newValue;
    }
}
