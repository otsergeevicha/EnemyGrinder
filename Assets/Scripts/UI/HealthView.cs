using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = 1;
        _gate.ChangedHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _gate.ChangedHealth -= ChangeHealth;
    }

    private void ChangeHealth(float currentValue, float maxValue)
    {
        currentValue /= maxValue;
        _slider.value = currentValue;
    }
}
