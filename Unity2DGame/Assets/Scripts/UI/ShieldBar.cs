using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void SetMaxShield(float shield)
    {
        slider.maxValue = shield;
        slider.value = shield;

        fill.color = gradient.Evaluate(1f);
    }


    public void SetShield(float shield)
    {
        slider.value = shield;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
