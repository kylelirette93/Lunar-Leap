using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetHealthBar(float amount)
    {
        // Set the slider attached to the health bar.
        healthSlider.value = amount;
    }

    public void SetHealthBarMax(float amount)
    {
        // Set the slider's max value to amount.
        healthSlider.maxValue = amount;
        SetHealthBar(amount);
    }
}
